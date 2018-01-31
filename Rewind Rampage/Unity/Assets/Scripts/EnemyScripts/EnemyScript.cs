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
    public AudioSource source;
    public List<AudioClip> kreunen = new List<AudioClip>();
    public bool died = false;
    public float vol;
    public float tauntTimer;
    public List<AudioClip> taunts = new List<AudioClip>();

    // Use this for initialization
    void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        tauntTimer -= Time.deltaTime;
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
        if(tauntTimer <= 0 && !died)
        {
            taunt();
            tauntTimer = Random.Range(1, 3);
        }
        Debug.DrawRay(rayPoint.position, rayPoint.forward * 1, Color.green);
        bool dead = transform.gameObject.GetComponent<MyHp>().dead;
        agent.SetDestination(target.position);
        if(dead == true && !died)
        {
            agent.isStopped=true;
            died = true;
            kreun();
        }
    }
    void kreun()
    {
        int kreunNo = Random.Range(0, kreunen.Count);
        source.PlayOneShot(kreunen[kreunNo], vol);
    }
    void taunt()
    {
        int tauntNo = Random.Range(0, taunts.Count);
        source.PlayOneShot(taunts[tauntNo], vol);
    }
}
