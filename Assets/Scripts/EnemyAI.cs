using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.position);
        
        if (i == 0)
        {
            Invoke("NavMeshDisable", 0.125f);
        }


    }

    public void NavMeshDisable()
    {
        navMeshAgent.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        i = i - 1;
        //Debug.Log(i);
    }

    private void OnTriggerEnter(Collider other)
    {
        i = i + 1;
        //Debug.Log(i);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<Level>().ActivateLoseCanvas();
        }

        if (collision.gameObject.name == "InActivatorCollider")
        {
            gameObject.SetActive(false);
        }
    }

}
