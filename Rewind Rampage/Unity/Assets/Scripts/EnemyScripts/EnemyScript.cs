using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {
    private NavMeshAgent agent;
    private Transform target;
    public float timer;
    public float backupTimer;
    public RaycastHit hit;
    public Transform rayPoint;
    public GameObject weapon;

	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timer = backupTimer;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (Physics.Raycast(rayPoint.position, rayPoint.forward, out hit, 1f))
            {
                if (hit.transform.tag == "Player")
                {
                    hit.transform.gameObject.GetComponent<PlayerHp>().DeathVoid(10);
                    timer = backupTimer;
                }
            }
        }
        Debug.DrawRay(rayPoint.position, rayPoint.forward * 1, Color.green);
        bool dead = transform.gameObject.GetComponent<MyHp>().dead;
        agent.SetDestination(target.position);
        if(dead == true)
        {
            agent.isStopped=true;
        }
    }
}
