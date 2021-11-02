using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EPaintings : MonoBehaviour
{
    public Animator EnemyPaintingAnimation;
    public FPSMovement fps;

    // Start is called before the first frame update
    void Start()
    {
        fps = GameObject.Find("Player").GetComponent<FPSMovement>();
        if (GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().SinglePlayer)
        {
            EnemyPaintingAnimation.SetBool("SinglePlayer", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
