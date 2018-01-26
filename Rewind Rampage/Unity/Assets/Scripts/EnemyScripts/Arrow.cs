using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public int damage;
    public float despawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        despawn -= Time.deltaTime;
        if (despawn < 0)
        {
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }
        if (collision.transform.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<PlayerHp>().DeathVoid(damage);
            Destroy(gameObject);
        }
    }
}
