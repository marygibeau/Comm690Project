using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperShredder : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        // destroy paper when collides with left wall
        if (col.gameObject.name == "LWall")
        {
            Destroy(gameObject);
        }
    }
}
