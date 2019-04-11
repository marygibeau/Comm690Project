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
    public Image menuPlanet;
    public Sprite[] planets;
    public LevelManager lvl;
    public bool canControl;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
        canControl = true;
    }

    public int currentWorld = 0;
    // public float speed = 0.1f;
     public void Update()
     {
         if(Input.GetKeyDown(KeyCode.RightArrow) && !(truckAnimator.GetCurrentAnimatorStateInfo(0).length > truckAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime) && canControl)
         {
             if (currentWorld == 0) {
                currentWorld = 1;
                truckAnimator.Play("truckAnimation0to1");
             } else if (currentWorld == 1) {
                currentWorld = 2;
                truckAnimator.Play("truckAnimation1to2");
             }
             
         }
         if(Input.GetKeyDown(KeyCode.LeftArrow) && !(truckAnimator.GetCurrentAnimatorStateInfo(0).length > truckAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime) && canControl)
         {
             if (currentWorld == 1) {
                currentWorld = 0;
                truckAnimator.Play("truckAnimation1to0");
             } else if (currentWorld == 2) {
                currentWorld = 1;
                truckAnimator.Play("truckAnimation2to1");
             }
         }

         if(Input.GetKeyDown(KeyCode.Return) && !(truckAnimator.GetCurrentAnimatorStateInfo(0).length > truckAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime)) {
             if (menuPanel.active == true) {
                 if (currentWorld == 0) {
                    lvl.LoadLevel("TitleScreen");
                 } else if (currentWorld == 1) {
                    lvl.LoadLevel("PaperIntro");
                 } else if (currentWorld == 2) {
                    lvl.LoadLevel("CompostWorld");
                 }
             }
             if (currentWorld == 0) {
                menuTitle.text = "Main Menu";
                menuSubtext.text = "Going to this planet will take you back to the main menu. Are you sure you want to proceed?";
                menuContinueText.text = "Press enter to continue to the menu";
                menuPlanet.sprite = planets[0];
                menuPanel.transform.position = transform.position;
                canControl = false;
                menuPanel.SetActive(true);
             } else if (currentWorld == 1) {
                menuTitle.text = "Facility";
                menuSubtext.text = "This is our HQ where all the magic is made... or thrown away, I guess. Are you sure you want to proceed?";
                menuContinueText.text = "Press enter to continue to the Waste Facility";
                menuPanel.transform.position = transform.position;
                menuPlanet.sprite = planets[1];
                canControl = false;
                menuPanel.SetActive(true);
             } else if (currentWorld == 2) {
                menuTitle.text = "Compost World";
                menuSubtext.text = "This planet STINKS! Literally. Are you sure you want to proceed?";
                menuContinueText.text = "Press enter to continue to the Compost Planet";
                menuPanel.transform.position = transform.position;
                menuPlanet.sprite = planets[2];
                canControl = false;
                menuPanel.SetActive(true);
             }
         }
         if(Input.GetKeyDown(KeyCode.Backspace)) {
             if (menuPanel.active == true) {
                canControl = true;
                 menuPanel.SetActive(false);
             }
         }
        
    }
}
