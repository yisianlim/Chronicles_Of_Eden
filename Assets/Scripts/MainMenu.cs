using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private Image exitBorder;
    private Image startBorder;

    private void Awake()
    {
        Transform startSelection = transform.Find("StartButton").GetChild(0);
        startBorder = startSelection.GetComponent<Image>();
        Transform exitSelection = transform.Find("ExitButton").GetChild(0);
        exitBorder = exitSelection.GetComponent<Image>();
    }

    public void StartGame() {
        startBorder.enabled = true;
        exitBorder.enabled = false;
        SceneManager.LoadScene("Main Level Copy");
    }


    public void ExitGame() {
        startBorder.enabled = false;
        exitBorder.enabled = true;
        Application.Quit();
    }
}
