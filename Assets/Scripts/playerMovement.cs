using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 7f;
    public float jump = 20f;
    public bool onGround = false;
    public bool facingRight = true;

    public bool pressed = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        transform.position = new Vector3(-3,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D) && !pressed)
        {
            transform.position += new Vector3(speed,0, 0) * Time.deltaTime;
            if (!facingRight) { // utropstäcken betyder motsattsen, alltså att facinRight INTE är true
                Flip();
            
            }
        }
        if (Input.GetKey(KeyCode.A) && !pressed)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            if (facingRight)
            {
                Flip();

            }
        }
        if (onGround && Input.GetKeyDown(KeyCode.Space) && !pressed)
        {
            rb.AddForce(new Vector3(0, jump,0), ForceMode2D.Impulse); //kan bara hoppa om onGround = true
            onGround = false; //Stoppar spelaren från att hoppa direkt
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true; // Kollar om spelaren rör marken
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false; // spelaren lämnar marken
        }
    }

    void Flip()
    {
        //multiplicerar spelarens skala med -1 så att den flippas
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
