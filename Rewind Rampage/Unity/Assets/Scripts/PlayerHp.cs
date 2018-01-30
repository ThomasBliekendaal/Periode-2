using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour {
    public int hp;
    public bool dead = false;
    public GameObject restartButton;
    public GameObject quitButton;
    public GameObject salutations;
    public List<GameObject> canvasTrash = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DeathVoid(int pain)
    {
        hp -= pain;
        if (hp == 0 && !dead)
        {
            dead = true;
        }
        if (dead == true)
        {
            Time.timeScale = 0;
            restartButton.SetActive(true);
            quitButton.SetActive(true);
            salutations.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            for (int i = 0; i < canvasTrash.Count; i++)
            {
                canvasTrash[i].SetActive(false);
            }
        }
    }
}
