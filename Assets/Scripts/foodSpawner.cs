using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles spawning of both food and trash
public class foodSpawner : MonoBehaviour
{
    public GameObject compost;
    public GameObject notCompost;
    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FoodSpawn", 3, 3);
        InvokeRepeating("TrashSpawn", 3, 5);
    }

// spawn food at random x and y
    public void FoodSpawn() {
        int x = (int) Random.Range(left.position.x + compost.GetComponent<SpriteRenderer>().bounds.size.x, right.position.x - compost.GetComponent<SpriteRenderer>().bounds.size.x);
        int y = (int) Random.Range(bottom.position.y + compost.GetComponent<SpriteRenderer>().bounds.size.y, top.position.y - compost.GetComponent<SpriteRenderer>().bounds.size.x);
        Instantiate(compost, new Vector2(x, y), Quaternion.identity);
    }

// spawn trash at random x and y
    public void TrashSpawn() {
        int x = (int) Random.Range(left.position.x + notCompost.GetComponent<SpriteRenderer>().bounds.size.x, right.position.x - notCompost.GetComponent<SpriteRenderer>().bounds.size.x);
        int y = (int) Random.Range(bottom.position.y + notCompost.GetComponent<SpriteRenderer>().bounds.size.y, top.position.y - notCompost.GetComponent<SpriteRenderer>().bounds.size.x);
        Instantiate(notCompost, new Vector2(x, y), Quaternion.identity);
    }
}
