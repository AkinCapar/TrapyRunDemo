using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody myBody;

    public Color redColor;
    MeshRenderer myRenderer;

    public float colorTime = 0.1f;

    private void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.position = new Vector3(transform.position.x, transform.position.y,
            transform.position.z);

        myRenderer = GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myBody.useGravity == true)
        {

            myRenderer.material.color = Color.Lerp(myRenderer.material.color,
                redColor, colorTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            myBody.useGravity = true;
        }
    }
}
