using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mom : InteractableObject
{
    
    public override void Interact()
    {
        var manager = FindObjectOfType<DialogueManager>();
        manager.StartDialogue(this.dialogue);
    }

}
