using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHp : MonoBehaviour {
    public Text text;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = player.GetComponent<PlayerHp>().hp.ToString();
	}
}
