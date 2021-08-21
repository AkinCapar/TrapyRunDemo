using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody myBody;
    public float moveForce = 10f;

    private DynamicJoystick joystick;




    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<DynamicJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveForce * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(myBody.velocity);

        if (joystick.Vertical < 0)
        {
            myBody.velocity = new Vector3(joystick.Horizontal, myBody.velocity.y,
                myBody.velocity.z);
        }

        else
        {
            myBody.velocity = new Vector3(joystick.Horizontal, myBody.velocity.y,
            joystick.Vertical);
        }
    }
}
