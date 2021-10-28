using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float speed = 10;
    private float horz, vert;
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
        transform.Translate(new Vector3(0, 0, vert) * (speed * Time.deltaTime));
        transform.Rotate(new Vector3(0f, horz, 0f)*(speed*10*Time.deltaTime));
    }
}
