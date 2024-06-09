using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public float damage;
    public bool attack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DummyScript dummyScript = collision.gameObject.GetComponent<DummyScript>();

            if (dummyScript != null && attack == true)
            {
                Debug.Log("Applying damage: " + damage);
                dummyScript.TakeDamage(damage);
            }
        }
        
    }
}