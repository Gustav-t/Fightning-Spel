using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ducking : MonoBehaviour
{
    public float normalHeight = 2.0f;
    public float duckHeight = 1.0f;
    private BoxCollider2D bc;
    private bool isDucking = false;
    private SpriteRenderer sr;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        // Set the initial size of the collider to normal height
        bc.size = new Vector2(bc.size.x, normalHeight);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isDucking)
        {
            Duck();
            
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && isDucking)
        {
            StandUp();
        }
    }

    void Duck()
    {
        isDucking = true;
        bc.size = new Vector2(bc.size.x, duckHeight);
        // Optionally, adjust the offset to reposition the collider
        bc.offset = new Vector2(bc.offset.x, bc.offset.y - (normalHeight - duckHeight) / 2);
    }

    void StandUp()
    {
        isDucking = false;
        bc.size = new Vector2(bc.size.x, normalHeight);
        // Reset the offset back to its original position
        bc.offset = new Vector2(bc.offset.x, bc.offset.y + (normalHeight - duckHeight) / 2);
    }
}