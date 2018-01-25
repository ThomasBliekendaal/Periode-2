using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public int damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform)
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<PlayerHp>().DeathVoid(damage);
        }
    }
}
