﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHp : MonoBehaviour {
    public int health;
    public GameObject explo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void DeathVoid (int pain){
        health -= pain;
        if (health < 0)
        {
            //GameObject b = Instantiate(explo, transform.position, Quaternion.identity);
            health = 0;
            //transform.gameObject.GetComponent<JumboManajer>().destroy(0);
            //Destroy(b, 3);
            //Destroy(gameObject);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}