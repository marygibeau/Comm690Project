using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBalloonController : MonoBehaviour
{
// paper world will end after 1 minute 15 seconds
    public Rigidbody2D rb;
    public Text paperText;
    public float jumpHeight;
    private int paperCounter;
    public int numberOfHearts;
    public int currentHealth;
    public Image[] hearts;
    public Sprite heart;
    public LevelManager lvler;
    public AudioSource source;
    public AudioClip collect;
    public AudioClip ouch;


    private void Start()
    {
        // resets paper collected
        paperCounter = 0;
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = collect;
    }

    void FixedUpdate()
    {
        // adds force in direction of key press
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
        // adds option to escape game
        if (Input.GetKey(KeyCode.Escape))
        {
            lvler.LoadLevel("map");
        }
        // changes health if injured
        if (currentHealth < numberOfHearts && currentHealth >= 0)
        {
            hearts[numberOfHearts - 1].enabled = false;
            numberOfHearts--;
        }
        // lose state
        if (currentHealth <= 0) {
            lvler.LoadLevel("GameOver");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // if collides with paper add to score
        if (col.gameObject.tag == "paper")
        {
            paperCounter++;
            paperText.text = "Papers Collected: " + paperCounter;
            Destroy(col.gameObject);
            source.clip = collect;
            source.Play();

        }
        // if collides with enemy decrease health
        if (col.gameObject.tag == "enemy")
        {
            currentHealth--;
            source.clip = ouch;
            source.Play();
            Destroy(col.gameObject);
        }
    }
}
