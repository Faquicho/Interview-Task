using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;
using UnityEditor.UI;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] activeDialogue;
    public float textSpeed;
    private int dialogueIndex;
    [SerializeField] GameObject dialoguePanel;

    void Start()
    {
        textComponent.text = string.Empty;
    }

    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (!dialoguePanel.activeInHierarchy)
        {
            textComponent.text = string.Empty;
            dialoguePanel.SetActive(true);
            activeDialogue = dialogue.dialogueLines;
            dialogueIndex = 0;
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in activeDialogue[dialogueIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    private void NextLine()
    {
        if(dialogueIndex < activeDialogue.Length - 1) 
        {
            Debug.Log(dialogueIndex);
            dialogueIndex++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

    private void OnClick(InputValue value)
    {
        if (value.isPressed)
        {
            if (textComponent.text == activeDialogue[dialogueIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = activeDialogue[dialogueIndex]; 
            }
        }
    }
}
