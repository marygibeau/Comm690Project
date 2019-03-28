using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timer;
    public LevelManager lvler;
    public float timeLeft;
    public bool countDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown) {
            timeLeft -= Time.deltaTime;
            timer.text = Mathf.FloorToInt(timeLeft) + " sec left";
            if (timeLeft <= 0) {
                lvler.LoadLevel("LevelComplete");
            }
        }
    }
}
