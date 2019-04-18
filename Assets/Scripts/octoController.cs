using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class octoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)) {
            // for now move otto right
            // eventually move angle of shot to the right
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            // for now move otto left
            // eventually move angle of shot to the left
        }
    }
}
