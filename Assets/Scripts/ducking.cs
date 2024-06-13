using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ducking : MonoBehaviour
{
    private int normalHeight;
    private float duckHeight;
    private BoxCollider2D bc;
    private bool isDucking = false;
    private SpriteRenderer sr;
    

    void Start()
    {
       
        bc = GetComponent<BoxCollider2D>();
        if (bc = null) {

            Debug.LogError("No boxCollider found on this object");
            return;
        }
        sr = GetComponent<SpriteRenderer>();
        if (sr = null)
        {

            Debug.LogError("No spriteRenderer found on this object");
            return;
        }
        // Set the initial size of the collider to normal height
        normalHeight = Mathf.RoundToInt(bc.bounds.size.y);

       
        duckHeight = normalHeight / 2.0f; 

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