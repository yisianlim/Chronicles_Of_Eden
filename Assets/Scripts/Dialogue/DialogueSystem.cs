using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    // DialogueSystem will be a singleton instance - only one instance
    // is needed throughout the lifetime of the game. 
    public static DialogueSystem Instance { get; set; }

    // UI elements for the DialogueSystem.
    public GameObject dialoguePanel;
    Button continueButton;
    Text dialogueText, nameText;
    
    // Keeps track of which line are we currently on. 
    int dialogueIndex;

    // UI elements are rendered based on these values. 
    private string npcName;
    private List<string> dialogueLines = new List<string>();

	void Awake () {
        // Initialize the UI elements of the dialogue system. 
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText= dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

        // Every time the continue button is clicked, the dialogue is continued in the UI.
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        // Dialogue panel is hidden at the start. 
        dialoguePanel.SetActive(false);

        // To ensure the the DialogueSystem remains a singleton instance.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
	}

    /// <summary>
    /// Initialize the dialogue system based on the current NPC that we are interacting with. 
    /// </summary>
    public void AddNewDialogue(NPCInteraction npcInteraction) {
        dialogueIndex = 0;
        dialogueLines = new List<string>(npcInteraction.dialogue.Length);
        dialogueLines.AddRange(npcInteraction.dialogue);
        npcName = npcInteraction.name;
        CreateDialogue();
    }

    /// <summary>
    /// Create the dialogue system. Actually show the player the dialogue panel. 
    /// </summary>
    public void CreateDialogue() {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    /// <summary>
    /// Delegated method with subscribes to the event of the user clicking the Continue button. 
    /// </summary>
    public void ContinueDialogue() {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else {
            dialoguePanel.SetActive(false);
        }
    }

	
}
