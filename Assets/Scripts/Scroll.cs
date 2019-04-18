using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for scrolling background animation
public class Scroll : MonoBehaviour
{

    float scrollSpeed = -30f;
    Vector2 startPos;

    void Start ()
    {
    	startPos = transform.position;
    }

    void Update ()
    {
        // this scolls for a minute 19
        // float newPos = Mathf.Repeat (Time.time * scrollSpeed, 20);
        transform.position = startPos + Vector2.right * (Time.time * scrollSpeed);
    }
}
