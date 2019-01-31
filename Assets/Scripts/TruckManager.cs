using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckManager : MonoBehaviour
{

    public Animator truckAnimator;
    public GameObject menuPanel;
    public Text menuTitle;
    public Text menuSubtext;
    public Text menuContinueText;
    public Image planet;
    public LevelManager lvl;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
    }

    public int currentWorld = 0;
    // public float speed = 0.1f;
     public void Update()
     {
         if(Input.GetKeyDown(KeyCode.RightArrow))
         {
             if (currentWorld == 0) {
                currentWorld = 1;
                truckAnimator.Play("truckAnimation0to1");
             } else if (currentWorld == 1) {
                currentWorld = 2;
                truckAnimator.Play("truckAnimation1to2");
             }
             
         }
         if(Input.GetKeyDown(KeyCode.LeftArrow))
         {
             if (currentWorld == 1) {
                currentWorld = 0;
                truckAnimator.Play("truckAnimation1to0");
             } else if (currentWorld == 2) {
                currentWorld = 1;
                truckAnimator.Play("truckAnimation2to1");
             }
         }

         if(Input.GetKeyDown(KeyCode.Return)) {
             if (menuPanel.active == true) {
                 if (currentWorld == 0) {
                    lvl.LoadLevel("TitleScreen");
                 } else if (currentWorld == 1) {
                    lvl.LoadLevel("Facility");
                 } else if (currentWorld == 2) {
                    lvl.LoadLevel("CompostWorld");
                 }
             }
             if (currentWorld == 0) {
                menuTitle.text = "Main Menu";
                menuSubtext.text = "Going to this planet will take you back to the main menu. Are you sure you want to proceed?";
                menuContinueText.text = "Press enter to continue to the menu";
                // planet.sprite = 
                // figure out a way to change sprite
                // probably store all planets in sprite array or use by name somehow
                menuPanel.transform.position = transform.position;
                menuPanel.SetActive(true);
             } else if (currentWorld == 1) {
                menuTitle.text = "Facility";
                menuSubtext.text = "This is our HQ where all the magic is made... or thrown away, I guess. Are you sure you want to proceed?";
                menuContinueText.text = "Press enter to continue to the Waste Facility";
                menuPanel.transform.position = transform.position;
                menuPanel.SetActive(true);
             } else if (currentWorld == 2) {
                menuTitle.text = "Compost World";
                menuSubtext.text = "This planet STINKS! Literally. Are you sure you want to proceed?";
                menuContinueText.text = "Press enter to continue to the Compost Planet";
                menuPanel.transform.position = transform.position;
                menuPanel.SetActive(true);
             }
         }
         if(Input.GetKeyDown(KeyCode.Backspace)) {
             if (menuPanel.active == true) {
                 menuPanel.SetActive(false);
             }
         }
        
    }
}
