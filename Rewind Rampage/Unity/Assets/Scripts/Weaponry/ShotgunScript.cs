using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour {
    public int pelletCount;
    public float spreadAngle;
    public float pelletFireVel=1;
    public GameObject pellet;
    public Transform barrel;
    List<Quaternion> pellets;
    public float rof;
    public float rofBackup;
    public AudioSource source;
    public AudioClip shot;
    public AudioClip pump;
    private float pumpTime = 1;
    private bool reloaded = false;

	void Awake () {
        rofBackup = rof;
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
	}
	

	void Update ()
    {
        rof -= Time.deltaTime;
        if(rof <= 0.3 && !reloaded)
        {
            source.PlayOneShot(pump, 1);
            reloaded = true;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            {
                pumpTime -= Time.deltaTime;
                if (rof < 0)
                {
                    fire();
                    source.PlayOneShot(shot, 1);
                    rof = rofBackup;
                    pumpTime = 1;
                    reloaded = false;
                }
            }
        }
	}
    void fire()
    {
        int i = 0;
        foreach(Quaternion quat in pellets)
        {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, barrel.position, barrel.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.forward * pelletFireVel);
            i++;
        }
    }
}
