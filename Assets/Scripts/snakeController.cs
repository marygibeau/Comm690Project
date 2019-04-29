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
    bool hurt = false;
    public GameObject tailPrefab;
    public Text scoreBoard;
    /*public AudiSource source;
    public AudioClip collect;
    public AudioClip ouch;*/

    void Start()
    {
        // sets initial direction to be right
        dir = Vector2.right * offset;
        // allows for rigid, non-continuous movement
        InvokeRepeating("Move", 0.01f, 0.1f);  
       /* source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = collect;*/  
    }

    void Update()
    {
        // change direction on key input
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

        // this saves the current position to be the offset
        Vector2 v = transform.position;
        // move head a step in direction
        transform.Translate(dir);
        // remove last piece of tail if injured
        if (hurt) {
            Transform bye = tail.ElementAt(tail.Count - 1);
            tail.RemoveAt(tail.Count - 1);
            Destroy(bye.gameObject);
            hurt = false;
        }
        // add new tail piece at end of snake on move
        if (ate) {
            // create new tail object
            GameObject g = (GameObject) Instantiate(tailPrefab, v, Quaternion.identity);
            // add to tail list
            tail.Insert(0, g.transform);
            ate = false;
        } else if (tail.Count > 0) {
            // mechanic to move snake along
            // basically a tail piece conveyor belt

            // move last tail element to where the head was
            tail.Last().position = v;
            // change tag to reflect now being first tail piece
            tail.Last().tag = "firstTail";
            // move last to first in array
            tail.Insert(0, tail.Last());
            // change tag of former first tail piece
            tail.ElementAt(1).tag = "tail";
            // remove old last element
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        // add to score and change game state when eat food
        if(other.tag == "compost") {
            ate = true;
            eatenCount++;
            scoreBoard.text = "Food Collected: " + eatenCount + "/15";
            // win condition
            if (eatenCount >= 15) {
                lvler.LoadLevel("LevelComplete");
            }
            // destroy old food and spawn new in its place
            Destroy(other.gameObject);
            foodie.FoodSpawn();
            /*source.clip = collect;
            source.Play();*/
        }

        // remove from score and change game state when eat trash
        if(other.tag == "notCompost") {
            hurt = true;
            eatenCount--;
            scoreBoard.text = "Food Collected: " + eatenCount + "/15";
            // lose condition
            if (eatenCount < 0) {
                Debug.Log("eaten count is " + eatenCount);
                lvler.LoadLevel("CompostOver");
            }
            // destroy trash and spawn new in its place
            Destroy(other.gameObject);
            foodie.TrashSpawn();
            /*source.clip = ouch;
            source.Play();*/
        }

        // lose condition if player collides with self
        if(this.tag == "Player" && other.tag == "tail") {
            lvler.LoadLevel("CompostOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // reset game if collide with wall
        if(other.collider.tag == "wall") {
            lvler.LoadLevel("CompostWorld");
        }    
    }
}
