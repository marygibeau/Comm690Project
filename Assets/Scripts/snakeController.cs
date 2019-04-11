using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class snakeController : MonoBehaviour
{
    // snake level will end when the snake has collected 30 food
    public LevelManager lvler;
    public foodSpawner foodie;
    public int eatenCount = 0;
    // refactor tail so it's a list of game objects so I can disable and reenable collider for first object
    List<Transform> tail = new List<Transform>();
    public int offset = 15;
    Vector2 dir = Vector2.right;
    bool ate = false;
    public GameObject tailPrefab;
    public Text scoreBoard;
    void Start()
    {
        dir = Vector2.right * offset;
        InvokeRepeating("Move", 0.01f, 0.1f);    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            dir = Vector2.right * offset;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            dir = -Vector2.up * offset;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            dir = -Vector2.right * offset;
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            dir = Vector2.up * offset;
        }
    }

    void Move() {
        // fix end of snake, it looks super weird
        // fix snake circles so they span further apart

        // this saves the current position to be the offset
        Vector2 v = transform.position;

        transform.Translate(dir);
        if (ate) {
            // create new tail object
            GameObject g = (GameObject) Instantiate(tailPrefab, v, Quaternion.identity);
            // add to tail list
            tail.Insert(0, g.transform);
            ate = false;
        } else if (tail.Count > 0) {
            // move last tail element to where the head was
            tail.Last().position = v;
            // add back to front and remove last
            tail.Last().tag = "firstTail";
            tail.Insert(0, tail.Last());
            tail.ElementAt(1).tag = "tail";
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.name.StartsWith("food")) {
            ate = true;
            eatenCount++;
            scoreBoard.text = "Food Collected: " + eatenCount + "/15";
            if (eatenCount >= 15) {
                lvler.LoadLevel("map");
            }
            Destroy(other.gameObject);
            foodie.Spawn();
        }
        if (other.tag == "wall") {
            lvler.LoadLevel("map");
        }

        if(this.tag == "Player" && other.tag == "tail") {
            lvler.LoadLevel("map");
            Debug.Log("collided with self");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "wall") {
            lvler.LoadLevel("CompostWorld");
        }    
    }
}
