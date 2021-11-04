using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject Self, Hud;
    public bool Multiplayer = false, SinglePlayer = false;
    public int P1Score=0, P2Score=0;
    //private int counter=0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Self);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startSinglePlayer()
    {
        SinglePlayer = true;
        SceneManager.LoadScene(1);
        //counter = 1;
        //TODO make single player shit
    }
    public void startingDoublePlayer()
    {
        Multiplayer = true;
        SceneManager.LoadScene(1);
        //counter = 1;
    }
    public void MoveToNextScene(int p1s, int p2s)
    {

        P1Score = p1s;
        P2Score = p2s;
    }
    public int getP1Score()
    {
        return P1Score;
    }
    public int getP2Score()
    {
        return P2Score;
    }
    public void setWC()
    {
        GameObject.Find("Player").GetComponent<FPSMovement>().setWinConditions();
    }
}
