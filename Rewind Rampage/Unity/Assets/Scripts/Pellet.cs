using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour {
    public int damage;
    public GameObject bloedParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GameObject b = Instantiate(bloedParticle, collision.contacts[0].point, transform.rotation);
            collision.transform.parent.gameObject.GetComponent<MyHp>().DeathVoid(damage);
        }
        if (collision.transform.tag == "EnemyHead")
        {
            collision.transform.parent.gameObject.GetComponent<MyHp>().DeathVoid(damage * 2);
        }
        if (collision.transform)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Destroy(gameObject, 10f);
    }
}
