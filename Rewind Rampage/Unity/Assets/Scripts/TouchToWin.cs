using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToWin : MonoBehaviour {
    public bool win = false;
    public GameObject restart;
    public GameObject quit;
    public GameObject congratulations;
    public List<GameObject> canvasTrash2 = new List<GameObject>();
    public AudioSource source;
    public AudioClip victory;

    void Start () {
		
	}
    private void Update()
    {
        if (win == true)
        {
            restart.SetActive(true);
            quit.SetActive(true);
            congratulations.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            source.Stop();
            source.PlayOneShot(victory, 1);
            for (int i = 0; i < canvasTrash2.Count; i++)
            {
                canvasTrash2[i].SetActive(false);
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            win = true;
        }
    }
}
