﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

//ToDo: add the EndInteraction() method from NPCInteractables to the end of the dialogue!
public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }

    public GameObject dialoguePanel;
    public NPC NPCInteract;


    public string npcName;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText;
    Text nameText;
    int dialogueIndex;

    void Start()
    {
        continueButton = dialoguePanel.transform.Find("OkButton").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").Find("Text").GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); } );

        dialoguePanel.SetActive(false);

		if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        
	}

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
