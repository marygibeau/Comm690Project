﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class snakeController : MonoBehaviour
{
    // snake level will end when the snake has collected 30 food
    public LevelManager lvler;
    public int eatenCount = 0;
    List<Transform> tail = new List<Transform>();
    Vector2 dir = Vector2.right;
    bool ate = false;
    public GameObject tailPrefab;
    void Start()
    {
        InvokeRepeating("Move", 0.01f, 0.01f);    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            dir = Vector2.right;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            dir = -Vector2.up;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            dir = -Vector2.right;
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            dir = Vector2.up;
        }
    }

    void Move() {
        // fix end of snake, it looks super weird
        // fix snake circles so they span further apart
        Vector2 v = transform.position;

        transform.Translate(dir);
        if (ate) {
            GameObject g = (GameObject) Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        } else if (tail.Count > 0) {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.name.StartsWith("food")) {
            ate = true;
            eatenCount++;
            if (eatenCount >= 15) {
                lvler.LoadLevel("map");
            }
            Destroy(other.gameObject);
        } else {
            lvler.LoadLevel("map");
        } 
    }
}
