using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
    public GameObject gun1;
    public GameObject gun2;
    public int count;
    

	// Use this for initialization
	void Start () {
        gun2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Q"))
        {
            count += 1;
            if (count > 2) 
            {
                count = 1;
            }
            if(count == 1)
            {
                gun2.SetActive(true);
                gun1.SetActive(false);
            }
            if (count == 2)
            {
                gun1.SetActive(true);
                gun2.SetActive(false);
                
            }
        }
	}
}
