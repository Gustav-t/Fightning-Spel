using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public float health = 5;

    public void TakeDamage(float damage)
    {
        Debug.Log("Taking damage: " + damage);
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Dummy died");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger detected with " + collision.gameObject.name);
    }
}

