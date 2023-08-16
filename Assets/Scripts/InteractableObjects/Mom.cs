using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : InteractableObject
{
    [SerializeField] GameObject dialoguePanel;
    public override void Interact()
    {
        dialoguePanel.SetActive(true);
    }

}
