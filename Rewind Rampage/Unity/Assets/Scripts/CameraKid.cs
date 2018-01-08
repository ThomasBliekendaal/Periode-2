using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKid : MonoBehaviour {
    public Vector3 rot;
    public float rotSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rot.x = -Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        transform.Rotate(rot);
    }
}
