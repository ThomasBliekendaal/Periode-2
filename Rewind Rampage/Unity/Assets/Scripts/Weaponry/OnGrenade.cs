using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGrenade : MonoBehaviour {
    public float timer;
    public float timerBackup;
    public GameObject particle;
    public float radius;
    public float force;
    public int damage;
    public bool exploded = false;
    // Use this for initialization
    void Start() {
        timer = timerBackup;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
    void Explode()
    {
        GameObject g = Instantiate(particle, transform.position, transform.rotation);
        Destroy(g, 1);
        Collider[] enemies = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in enemies)
        {
            MyHp hp = nearbyObject.GetComponent<MyHp>();
            if (hp != null)
            {
                hp.DeathVoid(damage);
            }
        }
        Destroy(gameObject);
    }
}
