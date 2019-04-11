using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawner : MonoBehaviour
{
    public GameObject food;
    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    public void Spawn() {
        int x = (int) Random.Range(left.position.x + food.GetComponent<SpriteRenderer>().bounds.size.x, right.position.x - food.GetComponent<SpriteRenderer>().bounds.size.x);
        int y = (int) Random.Range(bottom.position.y + food.GetComponent<SpriteRenderer>().bounds.size.y, top.position.y - food.GetComponent<SpriteRenderer>().bounds.size.x);
        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
