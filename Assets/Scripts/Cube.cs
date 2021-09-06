using System;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Invoke("CubeFall", 0.25f);
        }

        if (other.gameObject.name == "InActivatorCollider")
        {
            gameObject.SetActive(false);
        }
    }

    void CubeFall()
    {
        myBody.isKinematic = false;
        
        myRenderer.material.color = Color.Lerp(myRenderer.material.color,
            redColor, colorTime);
    }
}
