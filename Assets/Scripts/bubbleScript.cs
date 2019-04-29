using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleScript : MonoBehaviour
{
    // figure out how to show what color is about to spawn
    // get row of random bubbles to appear
    public int color;
    // Start is called before the first frame update
    void Start()
    {
        // assign bubble a random color trait
        System.Random rnd = new System.Random();
        color = rnd.Next(0, 3);
        Debug.Log("current bubble's color is: " + color);
        switch (color)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.1f, 0.3f, 1f);
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.2f, 1f, 1f);
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0.1f, 1);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
    // make it so checks color of nearby collisions and respond accordingly
    private void OnCollision2D(Collision2D other)
    {
        // could be implemented by creating a counter of nearby similar colors on object
        // on collision update current's by adding other's
        // would be difficult to destroy all touching similar ones
    }
}
