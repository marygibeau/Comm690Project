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

    void Spawn() {
        int x = (int) Random.Range(left.position.x, right.position.x);
        int y = (int) Random.Range(bottom.position.y, top.position.y);
        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
