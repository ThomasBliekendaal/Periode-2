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
    public GameObject barrel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
            barrel.GetComponent<Rigidbody>();
            {
                if (hit.transform.tag =="Enemy")
                {
                    GameObject b = Instantiate(bloed, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                    hit.transform.gameObject.GetComponent<MyHp>().DeathVoid(20);
                    Destroy(b, 6);
                    GameObject bp = Instantiate(bloedParticle, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                    b.transform.SetParent(hit.transform);
                    Destroy(bp, 1);
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
            }
        }
	}
}
