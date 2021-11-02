using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TittleMenu : MonoBehaviour
{
    public GameObject FirstScreen, PlayerOnecontrols, PlayerTwocontrols, P1Instructions, P2Instructions;
    private string activeScreen;
    public ScoreKeeper score;
    // Start is called before the first frame update
    void Start()
    {
        
        activeScreen = "MS";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)||Input.GetKey(KeyCode.Return))
        {
            Application.Quit();
        }
        //for allowing the player to press the z button to exit the control menu
        if(Input.GetKey(KeyCode.Alpha1) && activeScreen.Equals("SPCTR"))
        {
            FirstScreen.gameObject.SetActive(true);
            PlayerOnecontrols.SetActive(false);
            activeScreen = "MS";
        }
        if (Input.GetKey(KeyCode.Alpha2) && activeScreen.Equals("DPCTR"))
        {
            FirstScreen.gameObject.SetActive(true);
            PlayerTwocontrols.gameObject.SetActive(false);
            activeScreen = "MS";
        }
        if (Input.GetKey(KeyCode.Alpha1) && activeScreen.Equals("P1BE"))
        {
            FirstScreen.gameObject.SetActive(true);
            P1Instructions.SetActive(false);
            activeScreen = "MS";
        }
        if (Input.GetKey(KeyCode.Alpha2) && activeScreen.Equals("P2BE"))
        {
            FirstScreen.gameObject.SetActive(true);
            P2Instructions.SetActive(false);
            activeScreen = "MS";
        }

        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Keypad9) && activeScreen.Equals("MS"))
        {
            PlayerOneInstructionsbtnEvent();
        }
        if (Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.Keypad6) && activeScreen.Equals("MS"))
        {
            PlayerTwoInstructionsbtnEvent();
        }
        if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Keypad8))
        {
            PlayerOneControlsbtnEvent();
        }
        if (Input.GetKey(KeyCode.V) || Input.GetKey(KeyCode.Keypad5))
        {
            PlayerTwoControlsbtnEvent();
        }
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Keypad7 )&& activeScreen.Equals("MS"))
        {
            SinglePlayerbtnEvent();
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Keypad4) && activeScreen.Equals("MS"))
        {
            DoublePlayerbtnEvent();
        }
    }
    public void SinglePlayerbtnEvent()
    {
        score.startSinglePlayer();
    }
    public void PlayerOneControlsbtnEvent()
    {
        FirstScreen.gameObject.SetActive(false);
        PlayerOnecontrols.SetActive(true);
        activeScreen = "SPCTR";
    }
    public void PlayerOneInstructionsbtnEvent()
    {
        FirstScreen.gameObject.SetActive(false);
        P1Instructions.gameObject.SetActive(true);
        activeScreen = "P1BE";
    }
    public void DoublePlayerbtnEvent()
    {
        score.startingDoublePlayer();
    }
    public void PlayerTwoControlsbtnEvent()
    {
        FirstScreen.gameObject.SetActive(false);
        PlayerTwocontrols.SetActive(true);
        activeScreen = "DPCTR";
    }
    public void PlayerTwoInstructionsbtnEvent()
    {
        FirstScreen.gameObject.SetActive(false);
        P2Instructions.gameObject.SetActive(true);
        activeScreen = "P2BE";
    }

}
