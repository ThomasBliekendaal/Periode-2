using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumboManajer : MonoBehaviour {
    public GameObject bal;
    public GameObject bloed;
    public GameObject boem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DestroyObject (float timer)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(bal);
        }
    }
}
