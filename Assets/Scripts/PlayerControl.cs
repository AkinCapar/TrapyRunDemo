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
        transform.position += Vector3.forward * (moveForce * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            myBody.velocity = new Vector3(joystick.Horizontal * 4f, myBody.velocity.y,
                myBody.velocity.z);

            /*transform.eulerAngles += Vector3.up * (joystick.Horizontal * 10f);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Clamp(transform.eulerAngles.y, -90f, 90f),
                transform.eulerAngles.z);*/
        
            transform.LookAt(transform.position + Vector3.right * (joystick.Horizontal) + Vector3.forward * 0.5f);
        }
        else
        {
            var currentAngle = transform.eulerAngles;
            var angle = currentAngle.y > 180 ? (currentAngle - Vector3.up * 360f) : currentAngle;
            transform.eulerAngles = Vector3.Slerp(angle, Vector3.zero, Time.deltaTime * 4f);
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
