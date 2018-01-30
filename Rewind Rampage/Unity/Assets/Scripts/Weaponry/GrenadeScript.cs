using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour {
    public Transform hand;
    public float rof;
    public float rofBackup;
    public GameObject nade;
    public float nadeVel;
	// Use this for initialization
	void Start () {
        rofBackup = rof;
	}
	
	// Update is called once per frame
	void Update () {
        rof -= Time.deltaTime;
        if (rof < 0f)
        {
            rof = 0f;
        }
        if (rof == 0f)
        {
            if (Input.GetButtonDown("G"))
            {
                GameObject g = Instantiate(nade, hand.position, hand.rotation);
                g.GetComponent<Rigidbody>().AddForce(g.transform.forward * nadeVel);
                rof = rofBackup;
            }

        }
	}
}
