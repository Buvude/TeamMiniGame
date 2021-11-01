using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float speed = 10;
    private float horz, vert,straf;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        straf = Input.GetAxis("Strafe");
        transform.Translate(new Vector3(straf, 0, vert) * (speed * Time.deltaTime));
        transform.Rotate(new Vector3(0f, horz, 0f)*(speed*10*Time.deltaTime));
    }
}
