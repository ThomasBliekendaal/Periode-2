using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiQuit : MonoBehaviour {
    public Button button;
    // Use this for initialization
    void Start()
    {
        Button qbtn = button.GetComponent<Button>();
        qbtn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Application.Quit();
    }
}
