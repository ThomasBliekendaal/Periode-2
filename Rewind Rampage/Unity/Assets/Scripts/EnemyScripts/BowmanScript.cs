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
    public AudioSource source;
    public List<AudioClip> kreunen = new List<AudioClip>();
    public bool died = false;
    public float vol;
    public float tauntTimer;
    public List<AudioClip> taunts = new List<AudioClip>();

    // Use this for initialization
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {     
        tauntTimer -= Time.deltaTime;
        bool dead = transform.gameObject.GetComponent<MyHp>().dead;
        agent.SetDestination(target.position);
        if(dead == true && !died)
        {
            kreun();
            agent.isStopped = true;
            bow.GetComponent<BowmanBow>().enabled = false;
            bow.GetComponent<Rigidbody>().isKinematic = false;
            died = true;
        }
        if (tauntTimer <= 0 && !died)
        {
            taunt();
            tauntTimer = Random.Range(1, 3);
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
