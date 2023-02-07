using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stefan : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D Rigidbody;
    public float jumph;
    private bool isgrounded = false;
    private Vector3 rotation;

    public GameObject kamera;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        rotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");

        if (richtung > 0)
        {
            transform.eulerAngles = rotation -new Vector3(0, 180 ,0);
            transform.Translate(Vector2.right * speed * -richtung * Time.deltaTime);
        }
        if (richtung < 0)
        {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            Rigidbody.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isgrounded = false;
        }
        kamera.transform.position = new Vector3(transform.position.x, 0, -10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isgrounded = true;
        }
    }
}             