using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject Self;
    public bool Multiplayer = false, SinglePlayer = false;
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
    }
    public void startingDoublePlayer()
    {
        Multiplayer = true;
        SceneManager.LoadScene(1);
    }
}
