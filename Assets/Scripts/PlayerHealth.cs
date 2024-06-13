
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Rigidbody2D rb;
    public float health = 5;
    public bool isDamaged = false;
    public float imunity = 1f;
    float currentImunity;

    private void Update()
    {
        //skydd mot spamm
        currentImunity -= Time.deltaTime;
        if (currentImunity < 0)
        {
            isDamaged = false;
        }
        else
        {
            isDamaged = true;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float damage)
    {
        if (isDamaged == false)
        {
            currentImunity = imunity;

            Debug.Log("Taking damage: " + damage);
            health -= damage;

            //knockback
            rb.AddForce(new Vector2(damage * 100, 400));

            if (health <= 0)
            {
                Die();
            }
        }

    }

    private void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }


}

