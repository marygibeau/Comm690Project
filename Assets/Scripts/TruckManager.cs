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
        //   plays animations that go to the right based on world and changes world
        if (Input.GetKeyDown(KeyCode.RightArrow) && !(truckAnimator.GetCurrentAnimatorStateInfo(0).length > truckAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime) && canControl)
        {
            switch (currentWorld)
            {
                case 0:
                    currentWorld = 1;
                    truckAnimator.Play("truckAnimation0to1");
                    break;
                case 1:
                    currentWorld = 2;
                    truckAnimator.Play("truckAnimation1to2");
                    break;
                case 2:
                    currentWorld = 3;
                    truckAnimator.Play("truckAnimation2to3");
                    break;
                default:
                    break;
            }

        }
        // plays animations that go to the left and changes current planet
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !(truckAnimator.GetCurrentAnimatorStateInfo(0).length > truckAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime) && canControl)
        {
            switch (currentWorld)
            {
                case 1:
                    currentWorld = 0;
                    truckAnimator.Play("truckAnimation1to0");
                    break;
                case 2:
                    currentWorld = 1;
                    truckAnimator.Play("truckAnimation2to1");
                    break;
                case 3:
                    currentWorld = 2;
                    truckAnimator.Play("truckAnimation3to2");
                    break;
                default:
                    break;
            }
        }
        // handles enter key
        if (Input.GetKeyDown(KeyCode.Return) && !(truckAnimator.GetCurrentAnimatorStateInfo(0).length > truckAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime))
        {
            //  handles if panel is currently pulled up
            if (menuPanel.active == true)
            {
               switch (currentWorld) {
                  case 0:
                     lvl.LoadLevel("TitleScreen");
                     break;
                  case 1:
                     lvl.LoadLevel("PaperIntro");
                     break;
                  case 2:
                     lvl.LoadLevel("CompostWorld");
                     break;
                  case 3:
                     lvl.LoadLevel("Earth");
                     break;
               }
            }
            //  changes what is displayed in the panel based on current world
            switch (currentWorld)
            {
                case 0:
                    menuTitle.text = "Main Menu";
                    menuSubtext.text = "Going to this planet will take you back to the main menu. Are you sure you want to proceed?";
                    menuContinueText.text = "Press enter to continue to the menu";
                    menuPlanet.sprite = planets[0];
                    menuPanel.transform.position = transform.position;
                    canControl = false;
                    menuPanel.SetActive(true);
                    break;
                case 1:
                    menuTitle.text = "Paper World";
                    menuSubtext.text = "The bird-like inhabitants of this planet have been complaining about a paper problem. Are you sure you want to proceed?";
                    menuContinueText.text = "Press enter to continue to the Waste Facility";
                    menuPanel.transform.position = transform.position;
                    menuPlanet.sprite = planets[1];
                    canControl = false;
                    menuPanel.SetActive(true);
                    break;
                case 2:
                    menuTitle.text = "Compost World";
                    menuSubtext.text = "This planet STINKS! Literally. Are you sure you want to proceed?";
                    menuContinueText.text = "Press enter to continue to the Compost Planet";
                    menuPanel.transform.position = transform.position;
                    menuPlanet.sprite = planets[2];
                    canControl = false;
                    menuPanel.SetActive(true);
                    break;
                case 3:
                    menuTitle.text = "Earth";
                    menuSubtext.text = "The humans that live here have really messed this planet up. Are you sure you want to proceed?";
                    menuContinueText.text = "Press enter to continue to the Compost Planet";
                    menuPanel.transform.position = transform.position;
                    menuPlanet.sprite = planets[3];
                    canControl = false;
                    menuPanel.SetActive(true);
                    break;
            }
        }
        // gets rid of panel on backspace
        if (Input.GetKeyDown(KeyCode.Backspace) && menuPanel.active == true)
        {
            canControl = true;
            menuPanel.SetActive(false);
        }

    }
}
