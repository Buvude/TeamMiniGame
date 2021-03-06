using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public FPSMovement fps;
    // Start is called before the first frame update
    void Start()
    {
        fps = GameObject.Find("Player").GetComponent<FPSMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WinConditionFire")&&fps.getWeaponSelected()==3)
        {
            fps.addpointsP1(100);
            other.gameObject.SetActive(false);
            fps.FireDown();
        }
        else if (other.gameObject.CompareTag("WinConditionIce") && fps.getWeaponSelected() == 1)
        {
            fps.addpointsP1(100);
            other.gameObject.SetActive(false);
            fps.IceDown();
        }
        else if (other.gameObject.CompareTag("WinConditionWater") && fps.getWeaponSelected() == 2)
        {
            fps.addpointsP1(100);
            other.gameObject.SetActive(false);
            fps.WaterDown();
        }
    }
}
