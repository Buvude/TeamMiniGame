using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public ScoreKeeper sk;
    public Text PlayerWinText;

    // Start is called before the first frame update
    void Start()
    {
        sk = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
        if (sk.P1Score > sk.P2Score)
        {
            PlayerWinText.text = "congrats Player 1! You have finished with more points! press esc to close the game, and you can restart it if you want a rematch!";
        }
        else if (sk.P1Score < sk.P2Score)
        {
            PlayerWinText.text = "congrats Player 2! You have finished with more points! press esc to close the game, and you can restart it if you want a rematch!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
