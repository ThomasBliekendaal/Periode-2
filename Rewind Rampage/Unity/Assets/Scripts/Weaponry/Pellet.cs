using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour {
    public int damage;
    public GameObject bloedParticle;
    public GameObject confetti;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GameObject bp = Instantiate(bloedParticle, collision.contacts[0].point, transform.rotation);
            collision.transform.parent.gameObject.GetComponent<MyHp>().DeathVoid(damage);
            Destroy(bp, 1);
        }
        if (collision.transform.tag == "EnemyHead")
        {
            GameObject bp = Instantiate(bloedParticle, collision.contacts[0].point, transform.rotation);
            collision.transform.parent.gameObject.GetComponent<MyHp>().DeathVoid(damage * 2);
            Destroy(bp, 1);
        }
        if (collision.transform)
        {
            Destroy(gameObject);
            GameObject cf = Instantiate(confetti, collision.contacts[0].point, transform.rotation);
            Destroy(cf, 3);
        }
    }
    void Update()
    {
        Destroy(gameObject, 10f);
    }
}
