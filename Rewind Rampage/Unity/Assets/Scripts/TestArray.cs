using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArray : MonoBehaviour {
    public int[] i;
    public List<int> il = new List<int>();
	// Use this for initialization
	void Start () {
        i[5] = 500;
        if (i[2] == 20)
        {
            print("hoi");
        }
        il.Add(1);
        if (i.Length > 6)
        {
            i[8] = 3;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
