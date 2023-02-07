using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stefan : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
    }
}