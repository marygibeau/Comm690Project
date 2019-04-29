using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class octoController : MonoBehaviour
{
    public float offset = 0.1f;
    bool shooting = false;
    public int bubbleSpeed;
    public GameObject bubblePrefab;
    public LevelManager lvlr;
    private int bubblesShot;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBubble", 0, 0.2f);
        bubblesShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // for now move otto right
            // eventually move angle of shot to the right
            this.transform.Translate(Vector2.right * offset);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // for now move otto left
            // eventually move angle of shot to the left
            this.transform.Translate(Vector2.left * offset);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // toggles shooting on so shootBubble can handle it
            // this slows down shooting
            shooting = true;
        }
        // current end condition
        if (bubblesShot >= 10)
        {
            lvlr.LoadLevel("GameCompleted");
        }
    }

    void ShootBubble()
    {
        // creates new bubble of a random color and shoots it up
        if (shooting)
        {
            var newBub = Instantiate(bubblePrefab, this.transform.position, Quaternion.Euler(0, 0, 0));
            newBub.GetComponent<Rigidbody2D>().velocity = bubbleSpeed * transform.localScale.y * newBub.transform.up;
            shooting = false;
            bubblesShot++;
        }
    }
}
