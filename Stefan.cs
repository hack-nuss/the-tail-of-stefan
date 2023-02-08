using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stefan : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D Rigidbody;
    public float jumph;
    private bool isgrounded = false;
    private Vector3 rotation;

    PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;

    public new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        rotation = transform.eulerAngles;

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        jumpAction = playerInput.actions["jump"];
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");
        //var richtung = moveAction.ReadValue<Vector2>();

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

        //camera move
        camera.transform.position = new Vector3(transform.position.x, 0, -10);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isgrounded = true;
        }
    }
}             