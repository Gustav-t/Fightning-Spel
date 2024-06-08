using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedScript : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision detected with " + collision.gameObject.name);
            DummyScript dummyScript = collision.gameObject.GetComponent<DummyScript>();
            if (dummyScript != null)
            {
                Debug.Log("Applying damage: " + damage);
                dummyScript.TakeDamage(damage);
            }
            else
            {
                Debug.Log("No DummyScript found on " + collision.gameObject.name);
            }
        }
        
    }
}