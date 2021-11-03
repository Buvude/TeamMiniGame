using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPSMovement : MonoBehaviour
{
    public BoxCollider WinCondition;
    public Material pAttackMaterial;
    public Animator pAttack;
    public List<GameObject> enemyF = new List<GameObject>(); 
    public List<GameObject> enemyI = new List<GameObject>();
    public List<GameObject> enemyW = new List<GameObject>();
    public GameObject PlayerAttack, ScoreKeeper;
    private Color FireWeaponBase, FireweaponSelected, IceWeaponBase, IceWeaponSelected, WaterWeaponBase, WaterWeaponSelected;
    private Color FireDemonBase, FireDemonSelected, SnowGolemBase, SnowgolemSelected, KrakenBase, KrakenSelected;
    public Image FireWeapon, FireDemon,WaterWeapon,Kraken,IceWeapon,SnowGolem;
    public float speed = 10;
    private float horz, vert, straf;
    public GameObject Player;
    private int weaponSelected = 1, enemySelected = 1;
    private bool attackComplete = true, winConditionMet = false, eAttackComplete = true;
    public Text P1, P2, WC;
    public int score1 = 0, score2 = 0; 
    private int WinConditionsFire=0, WinConditionsWater=0, WinconditionsIce=0;
    // Start is called before the first frame update
    void Start()
    { 
        weaponSelected = 0;
        enemySelected = 0;
        ScoreKeeper = GameObject.Find("ScoreKeeper");
        ScoreKeeper.GetComponent<ScoreKeeper>().setWC();
        score1 = ScoreKeeper.GetComponent<ScoreKeeper>().getP1Score();
        score2 = ScoreKeeper.GetComponent<ScoreKeeper>().getP2Score();
        Cursor.visible = false;
        FireWeaponBase = new Color(255f, 255f, 255f);
        WaterWeaponBase = new Color(255f, 255f, 255f);
        IceWeaponBase= new Color(255f, 255f, 255f);
        FireDemonBase= new Color(255f, 255f, 255f);
        SnowGolemBase= new Color(255f, 255f, 255f);
        KrakenBase= new Color(255f, 255f, 255f);
        FireweaponSelected = new Color(255, 0, 0);
        IceWeaponSelected = new Color(0, 255, 245);
        WaterWeaponSelected = new Color(0, 0, 255);
        FireDemonSelected= new Color(255, 0, 0);
        SnowgolemSelected=new Color(0, 255, 245);
        KrakenSelected= new Color(0, 0, 255);

    }

    // Update is called once per frame
    void Update()
    {
        if (WinconditionsIce + WinConditionsWater + WinConditionsFire == 0)
        {
            winConditionMet = true;
            WC.text = "You have fulfilled the win conditions, you can now escape!";
        }
        else if (WinconditionsIce + WinConditionsWater + WinConditionsFire != 0)
        {
            WC.text = "You have the following win conditions yet to fulfill:\n" +
                "You are missing " + WinConditionsFire + " fireplaces\n" +
                "You are missing " + WinConditionsWater + " sailboats\n" +
                "You are missing " + WinconditionsIce + " igloos";
        }
        P1.text = "Player 1 Score: " + score1.ToString();
        P2.text = "Player 2 Score: " + score2.ToString();
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        straf = Input.GetAxis("Strafe");
        transform.Translate(new Vector3(straf, 0, vert) * (speed * Time.deltaTime));
        transform.Rotate(new Vector3(0f, horz, 0f) * (speed * 10 * Time.deltaTime));
        if (Input.GetKey(KeyCode.Z) && attackComplete)
        {
            weaponSelected = 1;
            FireWeapon.color = FireweaponSelected;
            WaterWeapon.color = WaterWeaponBase;
            IceWeapon.color = IceWeaponBase;
            pAttackMaterial.color = FireweaponSelected;
        }
        if (Input.GetKey(KeyCode.X) && attackComplete)
        {
            weaponSelected = 2;
            FireWeapon.color = FireWeaponBase;
            WaterWeapon.color = WaterWeaponBase;
            IceWeapon.color = IceWeaponSelected;

            pAttackMaterial.color = IceWeaponSelected;
        }
        if (Input.GetKey(KeyCode.C) && attackComplete)
        {
            weaponSelected = 3;
            FireWeapon.color = FireWeaponBase;
            WaterWeapon.color = WaterWeaponSelected;
            IceWeapon.color = IceWeaponBase;

            pAttackMaterial.color = WaterWeaponSelected;
        }
        if (Input.GetKey(KeyCode.Keypad7)&&ScoreKeeper.GetComponent<ScoreKeeper>().Multiplayer && eAttackComplete)
        {
            enemySelected = 1;
            FireDemon.color = FireDemonSelected;
            SnowGolem.color = SnowGolemBase;
            Kraken.color = KrakenBase;
        }
        if (Input.GetKey(KeyCode.Keypad8) && ScoreKeeper.GetComponent<ScoreKeeper>().Multiplayer && eAttackComplete)
        {
            enemySelected = 2;
            FireDemon.color = FireDemonBase;
            SnowGolem.color = SnowgolemSelected;
            Kraken.color = KrakenBase;
        }
        if (Input.GetKey(KeyCode.Keypad9) && ScoreKeeper.GetComponent<ScoreKeeper>().Multiplayer&&eAttackComplete)
        {
            enemySelected = 3;
            FireDemon.color = FireDemonBase;
            SnowGolem.color = SnowGolemBase;
            Kraken.color = KrakenSelected;
        }
        if (Input.GetKey(KeyCode.V) && attackComplete&& weaponSelected!=0)
        {
            switch (weaponSelected)
            {
                case 1:
                    pAttack.SetTrigger("FireAttack");
                    attackComplete = false;
                    break;
                case 2:
                    pAttack.SetTrigger("IceAttack");
                    attackComplete = false;
                    break;
                case 3:
                    pAttack.SetTrigger("WaterAttack");
                    attackComplete = false;
                    break;
            }
        }
        if (Input.GetKeyUp(KeyCode.Keypad5) && ScoreKeeper.GetComponent<ScoreKeeper>().Multiplayer && enemySelected != 0 && eAttackComplete)
        {
            Debug.Log("you made it this far...");
            switch (enemySelected)
            {
                case 1:
                    //eAttackF.SetTrigger("Fired");
                    /*for (int i = 0; i < enemyF.Count; i++)
                    {
                        enemyF[i].GetComponent<EPaintings>().Attack();
                    }
                    eAttackComplete = false;*/
                    foreach (GameObject i in enemyF)
                    {
                        i.GetComponent<EPaintings>().Attack();
                    }
                    break;
                case 2:
                    //eAttackI.SetTrigger("Fired");
                    /*for (int i = 0; i < enemyI.Count; i++)
                    {
                        enemyI[i].GetComponent<EPaintings>().Attack();
                    }
                    eAttackComplete = false;*/
                    foreach (GameObject i in enemyI)
                    {
                        i.GetComponent<EPaintings>().Attack();
                    }
                    break;
                case 3:
                    //eAttackW.SetTrigger("Fired");
                    /*for (int i = 0; i < enemyW.Count; i++)
                    {
                        enemyW[i].GetComponent<EPaintings>().Attack();
                    }*/
                    foreach (GameObject i in enemyW)
                    {
                        i.GetComponent<EPaintings>().Attack();
                    }
                    eAttackComplete = false;
                    break;
            }
        }

        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Return))
        {
            Application.Quit();
        }
        
        

    }
    public void resetAttackComplete()
    {
        attackComplete = true;
    }
    public void resetEattackReset()
    {
        eAttackComplete = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WinCondition") && winConditionMet && SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(1)))
        {
            ScoreKeeper.GetComponent<ScoreKeeper>().MoveToNextScene(score1, score2);
            SceneManager.LoadScene(2);
        }
        else if (other.CompareTag("WinCondition") && winConditionMet && SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(2)))
        {
            SceneManager.LoadScene(3);
        }
        else if (other.CompareTag("WinCondition"))
        {
            Player.transform.Translate(Vector3.back * 5);
        }
    }
    public void addpointsP1(int points)
    {
        score1 += points;
    }
    public void addpointsP2(int points)
    {
        score2 += points;
    }
    public int getWeaponSelected()
    {
        return weaponSelected;
    }
    public void setWinConditions(int fire, int water, int ice)
    {
        WinConditionsFire = fire;
        WinConditionsWater = water;
        WinconditionsIce = ice;
    }
    public void FireDown()
    {
        WinConditionsFire-=1;
    }
    public void IceDown()
    {
        WinconditionsIce-=1;
    }
    public void WaterDown()
    {
        WinConditionsWater-=1;
    }
    public void addEnemyPaintings(EPaintings epaint)
    {
        if (epaint.self.CompareTag("EnemyFire"))
        {
            //Debug.Log("One fire enemy should be added");
            enemyF.Add(epaint.self);
        }
        else if (epaint.CompareTag("EnemyIce"))
        {
            //Debug.Log("One ice enemy should be added");
            enemyI.Add(epaint.self);
        }
        else if (epaint.CompareTag("EnemyWater"))
        {
           //Debug.Log("One Water enemy should be added");
            enemyW.Add(epaint.self);
        }
    }
    

}
