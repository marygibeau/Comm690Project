using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySlicer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    
    }
}

