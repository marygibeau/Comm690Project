using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public float spawnTime = 0.5f;
    public int enemySpeed;
    private Vector2 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        // so paper and enemies don't collide
        Physics.IgnoreLayerCollision(8, 10, true);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn () {
        // spawn enemy off screen but at random y within range
        spawnPosition.x = 325f;
        spawnPosition.y = Random.Range(-150, 240);
        var spawnedEnemy1 = Instantiate(enemy1, spawnPosition, Quaternion.Euler(0, 0, 0));
        spawnedEnemy1.GetComponent<Rigidbody2D>().velocity = enemySpeed * transform.localScale.x * spawnedEnemy1.transform.right;
    }
}
