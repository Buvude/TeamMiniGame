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
    public GameObject PlayerAttack;
    private Color FireWeaponBase, FireweaponSelected,IceWeaponBase,IceWeaponSelected,WaterWeaponBase,WaterWeaponSelected;
    public Image FireWeapon, FireDemon;
    public float speed = 10;
    private float horz, vert, straf;
    public GameObject Player;
    private int weaponSelected = 1, enemySelected = 1;
    private bool attackComplete=true, winConditionMet=false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        FireWeaponBase = new Color(255f, 255f, 0);
        FireweaponSelected = new Color(255, 0, 0);
        IceWeaponSelected = new Color(0, 255, 245);
        WaterWeaponSelected = new Color(0, 0, 255);

    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        straf = Input.GetAxis("Strafe");
        transform.Translate(new Vector3(straf, 0, vert) * (speed * Time.deltaTime));
        transform.Rotate(new Vector3(0f, horz, 0f) * (speed * 10 * Time.deltaTime));
        if (Input.GetKey(KeyCode.Z)&&attackComplete)
        {
            weaponSelected = 1;
            FireWeapon.color = FireweaponSelected;
            pAttackMaterial.color = FireweaponSelected;
        }
        if (Input.GetKey(KeyCode.X)&&attackComplete)
        {
            weaponSelected = 2;
            FireWeapon.color = FireWeaponBase;
            pAttackMaterial.color = IceWeaponSelected;
        }
        if (Input.GetKey(KeyCode.C)&&attackComplete)
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
        if (Input.GetKey(KeyCode.V)&&attackComplete)
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
        if (other.CompareTag("WinCondition")&&winConditionMet&& SceneManager.GetActiveScene().Equals(SceneManager.GetSceneAt(1)))
        {
            SceneManager.LoadScene(2);
        }
        else if(other.CompareTag("WinCondition") && winConditionMet && SceneManager.GetActiveScene().Equals(SceneManager.GetSceneAt(2)))
        {
            SceneManager.LoadScene(3);
        }
        else if (other.CompareTag("WinCondition"))
        {
            Player.transform.Translate(Vector3.back*5);
        }
    }
}
