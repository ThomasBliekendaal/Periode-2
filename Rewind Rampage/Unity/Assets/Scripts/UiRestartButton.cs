using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiRestartButton : MonoBehaviour {
    public Button button;
    public GameObject deur;
	// Use this for initialization
	void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        deur.GetComponent<TouchToWin>().win = false;
    }
}
