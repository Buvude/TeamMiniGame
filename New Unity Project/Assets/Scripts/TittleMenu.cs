using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TittleMenu : MonoBehaviour
{
    public GameObject FirstScreen, SinglePlayerControls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)||Input.GetKey(KeyCode.Return))
        {
            Application.Quit();
        }
    }
    public void SinglePlayerbtnEvent()
    {

    }
    public void SinglePlayerControlsbtnEvent()
    {
        FirstScreen.gameObject.SetActive(false);
        SinglePlayerControls.SetActive(true);
    }
    public void SinglePlayerInstructionsbtnEvent()
    {

    }
    public void DoublePlayerbtnEvent()
    {

    }
    public void DoublePlayerControllsbtnEvent()
    {

    }
    public void DoublePlayerInstructionsbtnEvent()
    {

    }

}
