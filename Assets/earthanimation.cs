using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthanimation : MonoBehaviour
{
    Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator> ();
        anm.Play ("earth anim");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
