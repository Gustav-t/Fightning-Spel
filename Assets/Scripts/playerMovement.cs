using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2f;
    public float jump = 20f;
    private bool onGround = false;
    public bool facingRight = true;

    private MediumPlayerAttack midPlayerAttack;
    private LightPlayerAttack ligPlayerAttack;
    private HeavyPlayerAttack hevPlayerAttack;

    bool attack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        transform.position = new Vector3(-3,0,0);

        midPlayerAttack = GetComponent<MediumPlayerAttack>();
        ligPlayerAttack = GetComponent<LightPlayerAttack>();
        hevPlayerAttack = GetComponent<HeavyPlayerAttack>();


    }

    // Update is called once per frame
    void Update()
    {
        if (midPlayerAttack.pressed || ligPlayerAttack.pressed || hevPlayerAttack.pressed)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (Input.GetKey(KeyCode.D) && !attack)
        {
            transform.position += new Vector3(speed,0, 0) * Time.deltaTime;
            if (!facingRight) { // utropstäcken betyder motsattsen, alltså att facinRight INTE är true
                Flip();
            
            }
        }
        if (Input.GetKey(KeyCode.A) && !attack)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            if (facingRight)
            {
                Flip();

            }
        }
        if (onGround && Input.GetKeyDown(KeyCode.Space) && !attack)
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
