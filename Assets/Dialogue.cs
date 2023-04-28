using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public DialogueController dialogueController;
    public GameObject characterOne;
    public GameObject characterTwo;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController.dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogueController.dialogueBox.activeInHierarchy)
            {
                dialogueController.ChangeSpeakerIndicator();
                if (dialogueController.speakerIndicator.text == ">")
                {
                    dialogueController.StartDialogue(1);
                }
                else
                {
                    dialogueController.StartDialogue(2);
                }
            }
        }
    }
}
