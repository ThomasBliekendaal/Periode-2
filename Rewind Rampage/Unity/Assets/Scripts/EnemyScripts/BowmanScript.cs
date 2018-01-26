using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BowmanScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    public RaycastHit hit;
    public GameObject bow;

    // Use this for initialization
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {     
        bool dead = transform.gameObject.GetComponent<MyHp>().dead;
        agent.SetDestination(target.position);
        if(dead == true)
        {
            agent.isStopped = true;
            bow.GetComponent<BowmanBow>().enabled = false;
            bow.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
