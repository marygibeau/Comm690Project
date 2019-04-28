using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class octoController : MonoBehaviour
{
    public float offset = 0.1f;
    bool shooting = false;
    public GameObject bubblePrefab;
    // Start is called before the first frame update
    void Start()
    {
    InvokeRepeating("ShootBubble", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)) {
            // for now move otto right
            // eventually move angle of shot to the right
            this.transform.Translate(Vector2.right * offset);
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            // for now move otto left
            // eventually move angle of shot to the left
            this.transform.Translate(Vector2.left * offset);
        }
        if(Input.GetKey(KeyCode.Space)) {
            shooting = true;
        }
    }

    void ShootBubble() {
        if (shooting) {
            Instantiate(bubblePrefab, this.transform.position, Quaternion.identity);
            shooting = false;
        }
    }
}
