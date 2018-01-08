using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    public float speed;
    public int jumps;
    public Vector3 jumpv;
    public Vector3 rotatev;
    public float rotatevSpeed;
    public int totalJumps;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        transform.Translate(strafe, 0, translation);

        if (Input.GetButtonDown("Jump"))
        {
            if (jumps > 0)
            {
                GetComponent<Rigidbody>().velocity += jumpv;
                jumps -= 1;
            }
        }
        rotatev.y = Input.GetAxis("Mouse X") * rotatevSpeed * Time.deltaTime;
        transform.Rotate(rotatev);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            jumps = totalJumps;
        }
    }
}
