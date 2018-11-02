using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    // UI elements for TutorialManager.
    public Text nameText;
    public Text dialogueText;
    public Button button;
    public Animator animator;

    // Check if the first item has been picked up.
    public Pickup firstPickup;

    // Dialogues for the tutorial.
    public Dialogue dialogue;
    private List<string> sentences;

    // The current tutorial that we are at.
    private int popUpIndex = -1;

    // Flag to check if the tutorial has already started.
    private bool startTutorial = false;

    // Check if a dialogue is already typing. 
    private bool typing = false;

    private void Start()
    {
        button.gameObject.SetActive(false);
        sentences = new List<string>();
        nameText.text = dialogue.name;
        foreach (string s in dialogue.sentences)
        {
            sentences.Add(s);
        }
    }

    void Update()
    {
        // Wait for a few seconds before beginning the tutorial.
        if (startTutorial == false)
        {
            StartCoroutine(BeginTutorial());
        }

        CheckPlayerInputs();
        Display();
    }

    /// <summary>
    /// Check the player inputs, in order to keep track of the tutorial to 
    /// be displayed. 
    /// </summary>
    void CheckPlayerInputs() {
        // Check if player moves using the WASD key or arrow keys.
        if (popUpIndex == 0 && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            MoveToNextTutorial();
        }
        // Check if player learned how to dodged.
        else if (popUpIndex == 1 &&
            (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && Input.GetKeyDown(KeyCode.Space))
        {
            MoveToNextTutorial();
        }
        // Check that player learned to attack.
        else if (popUpIndex == 2 && Input.GetMouseButtonDown(1))
        {
            MoveToNextTutorial();
        }
        // Check that the first item has already been successfully picked up.
        else if (popUpIndex == 3 && firstPickup.pickedUp)
        {
            MoveToNextTutorial();
        }
        // Check that the picked up item is equipped.
        else if (popUpIndex == 4 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveToNextTutorial();
        }
        // Check that the bomb is used.
        else if (popUpIndex == 5 && Input.GetMouseButtonDown(0))
        {
            MoveToNextTutorial();
        }
        // End of tutorial.
        else if (popUpIndex == 6) {
            StartCoroutine(EndTutorial());
        }

    }

    /// <summary>
    /// Display the tutorial dialogue if there is still more tutorials
    /// to show. 
    /// </summary>
    void Display() {
        if (popUpIndex >= 0 && popUpIndex < sentences.Count)
        {
            animator.SetBool("IsOpen", true);
            if (typing == false)
            {
                StopAllCoroutines();
                StartCoroutine(TypeSentence(sentences[popUpIndex]));
            }
        }
        else
        {
            animator.SetBool("IsOpen", false);
        }
    }

    /// <summary>
    /// Wait for 2 seconds before we begin the tutorial.
    /// </summary>
    IEnumerator BeginTutorial()
    {
        startTutorial = true;
        yield return new WaitForSeconds(2);
        popUpIndex = 0;
    }

    /// <summary>
    /// Wait for 3 seconds before we end the tutorial.
    /// </summary>
    IEnumerator EndTutorial() {
        yield return new WaitForSeconds(3);
        popUpIndex++;
    }

    /// <summary>
    /// Type the sentence character by character.
    /// </summary>
    /// <param name="sentence">Sentence to type.</param>
    IEnumerator TypeSentence(string sentence)
    {
        typing = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    /// <summary>
    /// Display the next tutorial to the user. 
    /// </summary>
    void MoveToNextTutorial() {
        popUpIndex++;
        typing = false;
    }
}
