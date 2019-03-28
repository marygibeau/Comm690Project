using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperShredder : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "LWall")
        {
            Destroy(gameObject);
        }
    }
}
