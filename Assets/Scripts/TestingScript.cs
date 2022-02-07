using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2d.AddForce(new Vector2(0f, 10f));
        }

        if (Input.GetKey(KeyCode.S)){
            rigidbody2d.AddForce(new Vector2(0f, -10f));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.AddForce(new Vector2(-10f, 0f));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.AddForce(new Vector2(10f, 0f));
        }
    }
}
