using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;
using UnityEditor.UI;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int dialogueIndex;
    [SerializeField] GameObject dialoguePanel;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        
    }

    private void StartDialogue()
    {
        dialogueIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[dialogueIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    private void NextLine()
    {
        if(dialogueIndex < lines.Length) 
        {
            dialogueIndex++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
    }

    private void OnClick(InputValue value)
    {
        if (value.isPressed)
        {
            if (textComponent.text == lines[dialogueIndex])
            {
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(false);
                StopAllCoroutines();
                textComponent.text = lines[dialogueIndex];
            }
        }
    }
}
