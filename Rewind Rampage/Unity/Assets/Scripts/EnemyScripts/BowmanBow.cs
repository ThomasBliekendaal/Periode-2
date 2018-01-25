using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowmanBow : MonoBehaviour {
    public float rof;
    public float rofBackup;
    public Transform bowBarrel;
    public GameObject Arrow;
    public Transform target;
    public float arrowFireVel;

	// Use this for initialization
	void Start () {
        rofBackup = rof;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        rof -= Time.deltaTime;
        if (rof < 0)
        {
            GameObject a = Instantiate(Arrow, bowBarrel.position, bowBarrel.rotation);
            a.GetComponent<Rigidbody>().AddForce(a.transform.forward * arrowFireVel);
            rof = rofBackup;
        }
	}
}
