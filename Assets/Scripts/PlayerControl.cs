using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody myBody;
    public float moveForce = 10f;



    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveForce * Time.deltaTime; 
    }
}
