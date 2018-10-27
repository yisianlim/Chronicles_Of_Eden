using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    // TutorialManager will be a singleton instance - only one instance
    // is needed throughout the lifetime of the game. 
    public static TutorialManager Instance { get; set; }

    // UI elements for TutorialManager.
    public GameObject tutorialPanel;
    Text tutorialText;

    // Keeps track of which tutorial we are currently at. 
    private int popUpIndex = 0;

    // List of instructions. 
    public List<string> lines = new List<string>();

    private void Awake()
    {
        // Initialize the UI elements. 
        tutorialText = tutorialPanel.transform.Find("Text").GetComponent<Text>();

        // Panel is shown at the start. 
        tutorialPanel.SetActive(true);

        // To ensure the the TutorialManager remains a singleton instance.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update () {

        if (popUpIndex == 0)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                popUpIndex++;
            }
        }

        if (popUpIndex < lines.Count)
        {
            tutorialText.text = lines[popUpIndex];
            tutorialPanel.SetActive(true);
        }
        else {
            tutorialPanel.SetActive(false);
        }
	}
}
