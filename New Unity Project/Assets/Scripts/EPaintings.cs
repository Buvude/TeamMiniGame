using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EPaintings : MonoBehaviour
{
    public Animator EnemyPaintingAnimation;
    public FPSMovement fps;
    public GameObject self;
    private int type;

    // Start is called before the first frame update
    void Start()
    {
        fps = GameObject.Find("Player").GetComponent<FPSMovement>();
        if (GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().SinglePlayer)
        {
            EnemyPaintingAnimation.SetBool("SinglePlayer", true);
        }
        if (self.gameObject.CompareTag("EnemyFire"))
        {
            type = 1;
        }
        else if (self.gameObject.CompareTag("EnemyIce"))
        {
            type = 2;
        }
        else if (self.gameObject.CompareTag("EnemyWater"))
        {
            type = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetAttackk()
    {
        fps.resetEattackReset();
    }
    
}
