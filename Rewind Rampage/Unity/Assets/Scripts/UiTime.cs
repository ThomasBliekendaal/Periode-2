using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTime : MonoBehaviour {
    public GameObject time;
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = time.GetComponent<Spawns>().survivalTimer.ToString();
        if(time.GetComponent<Spawns>().survivalTimer < 0)
        {
            text.text = ("RUN!");
        }
	}
}
