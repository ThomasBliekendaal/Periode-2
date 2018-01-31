using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShit : MonoBehaviour {
    public RaycastHit hit;
    public GameObject bloed;
    public GameObject puff;
    public GameObject puffParticle;
    public GameObject bloedParticle;
    public GameObject bloedParent;
    public float impact;
    public Transform barrel;
    public float rof;
    public float rofTime;
    public bool firing;
    public GameObject muzzleFlash;
    public GameObject cool;
    public GameObject muurPuff;
    public GameObject muurPuffParticle;
    public Transform rayPoint;
    public int damage;
    public GameObject houtPuff;
    public GameObject houtPuffParticle;
    public AudioSource source;
    public AudioClip shot;
    public AudioClip bImpact;

	void Update () {
        if (firing == false)
        {
            rofTime -= Time.deltaTime;
            if(rofTime <= 0)
            {
                rofTime = 0;
            }
        }

        Debug.DrawRay(rayPoint.position, rayPoint.forward * 10, Color.green);
        if (Input.GetButton("Fire1"))
        {
            firing = true;
            rofTime -= Time.deltaTime;
            if (rofTime <= 0)
            {
                barrel.GetComponent<Rigidbody>();
                rofTime = rof;
                GameObject mf = Instantiate(muzzleFlash, barrel.transform);
                Destroy(mf, 1);
                source.PlayOneShot(shot, 1);
                if (Physics.Raycast(rayPoint.position, rayPoint.forward, out hit, 1000f))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        GameObject b = Instantiate(bloed, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        hit.transform.parent.gameObject.GetComponent<MyHp>().DeathVoid(damage);
                        Destroy(b, 6);
                        GameObject bp = Instantiate(bloedParticle, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        b.transform.SetParent(hit.transform);
                        Destroy(bp, 1);
                        source.PlayOneShot(bImpact, 1);
                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impact);
                        }

                    }
                    if (hit.transform.tag == "Floor")
                    {
                        GameObject p = Instantiate(puff, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        Destroy(p, 6);
                        GameObject pp = Instantiate(puffParticle, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        Destroy(pp, 1);
                    }
                    if (hit.transform.tag == "EnemyHead")
                    {
                        GameObject b = Instantiate(bloed, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        hit.transform.parent.gameObject.GetComponent<MyHp>().DeathVoid(damage * 2);
                        Destroy(b, 6);
                        GameObject bp = Instantiate(bloedParticle, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        b.transform.SetParent(hit.transform);
                        Destroy(bp, 1);
                        source.PlayOneShot(bImpact, 1);
                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impact);
                        }
                    }
                    if (hit.transform.tag == "CastleWalls")
                    {
                        GameObject mp = Instantiate(muurPuff, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        Destroy(mp, 6);
                        GameObject mpp = Instantiate(muurPuffParticle, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        Destroy(mpp, 1);
                    }
                    if (hit.transform.tag == "HoutMuur")
                    {
                        GameObject hp = Instantiate(houtPuff, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        Destroy(hp, 6);
                        GameObject hpp = Instantiate(houtPuffParticle, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                        Destroy(hpp, 1);
                    }
                }
            }
        }
        else
        {
            firing = false;
        }
    }

}