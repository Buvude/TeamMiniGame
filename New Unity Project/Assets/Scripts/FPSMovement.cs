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
    public GameObject PlayerAttack, ScoreKeeper;
    private Color FireWeaponBase, FireweaponSelected, IceWeaponBase, IceWeaponSelected, WaterWeaponBase, WaterWeaponSelected;
    public Image FireWeapon, FireDemon;
    public float speed = 10;
    private float horz, vert, straf;
    public GameObject Player;
    private int weaponSelected = 1, enemySelected = 1;
    private bool attackComplete = true, winConditionMet = false;
    public Text P1, P2, WC;
    public int score1 = 0, score2 = 0; 
    private int WinConditionsFire=0, WinConditionsWater=0, WinconditionsIce=0;
    // Start is called before the first frame update
    void Start()
    {
        weaponSelected = 0;
        ScoreKeeper = GameObject.Find("ScoreKeeper");
        ScoreKeeper.GetComponent<ScoreKeeper>().setWC();
        score1 = ScoreKeeper.GetComponent<ScoreKeeper>().getP1Score();
        score2 = ScoreKeeper.GetComponent<ScoreKeeper>().getP2Score();
        Cursor.visible = false;
        FireWeaponBase = new Color(255f, 255f, 0);
        FireweaponSelected = new Color(255, 0, 0);
        IceWeaponSelected = new Color(0, 255, 245);
        WaterWeaponSelected = new Color(0, 0, 255);

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
            pAttackMaterial.color = FireweaponSelected;
        }
        if (Input.GetKey(KeyCode.X) && attackComplete)
        {
            weaponSelected = 2;
            FireWeapon.color = FireWeaponBase;
            pAttackMaterial.color = IceWeaponSelected;
        }
        if (Input.GetKey(KeyCode.C) && attackComplete)
        {
            weaponSelected = 3;
            FireWeapon.color = FireWeaponBase;
            pAttackMaterial.color = WaterWeaponSelected;
        }
        if (Input.GetKey(KeyCode.Keypad7))
        {
            enemySelected = 1;
        }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            enemySelected = 2;
        }
        if (Input.GetKey(KeyCode.Keypad9))
        {
            enemySelected = 3;
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
            if (Input.GetKey(KeyCode.Keypad5))
            {
                switch (enemySelected)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
        }
        {
            if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }

    }
    public void resetAttackComplete()
    {
        attackComplete = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WinCondition") && winConditionMet && SceneManager.GetActiveScene().Equals(SceneManager.GetSceneAt(1)))
        {
            ScoreKeeper.GetComponent<ScoreKeeper>().MoveToNextScene(score1, score2);
            SceneManager.LoadScene(2);
        }
        else if (other.CompareTag("WinCondition") && winConditionMet && SceneManager.GetActiveScene().Equals(SceneManager.GetSceneAt(2)))
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

}
