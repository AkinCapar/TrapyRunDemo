using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody myBody;
    public float moveForce = 10f;

    private DynamicJoystick joystick;

    private float verticalAllowence = 0f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<DynamicJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * moveForce);
        transform.position += transform.forward * moveForce * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(myBody.velocity);

        if (joystick.Vertical <= verticalAllowence)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "RotatingStick")
        {
          //  myBody.constraints = RigidbodyConstraints.None ;
        }

        if (collision.gameObject.name == "Finish Zone")
        {
            FindObjectOfType<Level>().ActivateWinCanvas();
        }
    }


}
