using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    private FPSMovement fps;
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
        if (other.gameObject.CompareTag("Player"))
        {
            fps.addpointsP2(50);
        }
    }
}
