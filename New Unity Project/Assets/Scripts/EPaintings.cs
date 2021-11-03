using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EPaintings : MonoBehaviour
{
    //public Animator eAttackF, eAttackI, eAttackW;
    public Animator selfAnimation;
    public FPSMovement fps;
    public GameObject self;
    //private int type;

    // Start is called before the first frame update
    void Start()
    {
        fps = GameObject.Find("Player").GetComponent<FPSMovement>();
        if (GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().SinglePlayer)
        {
            /*eAttackF.SetBool("SinglePlayer", true);
            eAttackW.SetBool("SinglePlayer", true);
            eAttackI.SetBool("SinglePlayer", true);*/
            selfAnimation.SetBool("SinglePlayer", true);
        }
        fps.addEnemyPaintings(this.GetComponent<EPaintings>());
        /*if (self.gameObject.CompareTag("EnemyFire"))
        {
            type = 1;
            //fps.addEnemyPaintings(this);
        }
        else if (self.gameObject.CompareTag("EnemyIce"))
        {
            type = 2;
            //fps.addEnemyPaintings(this);
        }
        else if (self.gameObject.CompareTag("EnemyWater"))
        {
            type = 3;
            //fps.addEnemyPaintings(this);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetAttackk()
    {
        fps.resetEattackReset();
    }
    public void Attack()
    {
        /*switch (type)
        {
            case 1:
                eAttackF.SetTrigger("Fired");
                break;
            case 2:
                eAttackI.SetTrigger("Fired");
                break;
            case 3:
                eAttackW.SetTrigger("Fired");
                break;
        }*/
        selfAnimation.SetTrigger("Fired");
    }
    
}
