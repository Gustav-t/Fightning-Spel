using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ducking : MonoBehaviour
{
    public float normalHeight = 2.0f;
    public float duckHeight = 1.0f;
    private BoxCollider2D boxCollider;
    private bool isDucking = false;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        // Set the initial size of the collider to normal height
        boxCollider.size = new Vector2(boxCollider.size.x, normalHeight);
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
        boxCollider.size = new Vector2(boxCollider.size.x, duckHeight);
        // Optionally, adjust the offset to reposition the collider
        boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.offset.y - (normalHeight - duckHeight) / 2);
    }

    void StandUp()
    {
        isDucking = false;
        boxCollider.size = new Vector2(boxCollider.size.x, normalHeight);
        // Reset the offset back to its original position
        boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.offset.y + (normalHeight - duckHeight) / 2);
    }
}