using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text speakerName;
    public Text dialogueText;
    public Text speakerIndicator;
    public GameObject dialogueBox;
    public float typingSpeed = 0.02f;
    public string[] characterOneDialogue;
    public string[] characterTwoDialogue;
    public string[] currentDialogue;
    public string[] currentSpeakerNames;
    private int currentIndex;
    private bool isTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        speakerIndicator.text = ">";
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                isTyping = false;
                dialogueText.text = currentDialogue[currentIndex];
            }
            else
            {
                currentIndex++;
                if (currentIndex >= currentDialogue.Length)
                {
                    dialogueBox.SetActive(false);
                }
                else
                {
                    StartCoroutine(TypeText(currentDialogue[currentIndex]));
                }
            }
        }
    }

    public void StartDialogue(int dialogueIndex)
    {
        if (dialogueIndex == 1)
        {
            currentDialogue = characterOneDialogue;
            currentSpeakerNames = new string[] { "Character One", "Character Two" };
        }
        else
        {
            currentDialogue = characterTwoDialogue;
            currentSpeakerNames = new string[] { "Character Two", "Character One" };
        }
        currentIndex = -1;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeText(currentDialogue[currentIndex + 1]));
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void ChangeSpeakerIndicator()
    {
        if (speakerIndicator.text == ">")
        {
            speakerIndicator.text = "<";
            speakerName.text = currentSpeakerNames[1];
        }
        else
        {
            speakerIndicator.text = ">";
            speakerName.text = currentSpeakerNames[0];
        }
    }
}
