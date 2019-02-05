using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSpawner : MonoBehaviour
{
    public GameObject paperPrefab;
    public float spawnTime = 2f;
    public int paperSpeed;
    private Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        paperSpeed = -100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn () {
        spawnPosition.x = 250f;
        spawnPosition.y = Random.Range(-200, 200);
        var spawnedPaper = Instantiate(paperPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
        spawnedPaper.GetComponent<Rigidbody2D>().velocity = paperSpeed * transform.localScale.x * spawnedPaper.transform.right;
    }
}
