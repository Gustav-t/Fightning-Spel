using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        transform.position = new Vector3(-3,0,0);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           rb.AddForce(new Vector3 (0, 5, 0), ForceMode2D.Impulse);
        }
       
    }
}
