using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGrenade : MonoBehaviour {
    public GameObject grenade;
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = grenade.GetComponent<GrenadeScript>().rof.ToString();
        if (grenade.GetComponent<GrenadeScript>().rof == 0)
        {
            text.text = ("READY");
        }
	}
}
