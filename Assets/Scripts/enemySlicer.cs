using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// destroys an enemy if they leave the screen or hit player
public class enemySlicer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        Destroy(gameObject);    
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //  destroy if leave screen via left
        if (col.gameObject.name == "LWall")
        {
            Destroy(gameObject);
        }
        // destroy on contact with player
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    
    }
}

