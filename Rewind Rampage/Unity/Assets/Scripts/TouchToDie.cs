using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToDie : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.gameObject.GetComponent<PlayerHp>().DeathVoid(100);
    }
}
