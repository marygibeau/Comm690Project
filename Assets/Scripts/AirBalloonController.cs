﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBalloonController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Text paperText;
    public float jumpHeight;
    private int paperCounter;
    public int numberOfHearts;
    public static int currentHealth;
    public Image[] hearts;
    public Sprite heart;

    private void Start()
    {
        paperCounter = 0;
        // paperText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
        }
        if (currentHealth < numberOfHearts)
        {
            hearts[numberOfHearts - 1].enabled = false;
            numberOfHearts--;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision!");
        if (col.gameObject.tag == "paper")
        {
            paperCounter++;
            paperText.text = "Papers Collected: " + paperCounter;
            Destroy(col.gameObject);
        }
    }
}
