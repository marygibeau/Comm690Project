using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSlide : MonoBehaviour
{
    Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator> ();
        anm.Play ("TextSlide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
