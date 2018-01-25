using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour {
    public int hp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DeathVoid(int pain)
    {
        hp -= pain;
        if (hp < 0)
        {

        }
    }
}
