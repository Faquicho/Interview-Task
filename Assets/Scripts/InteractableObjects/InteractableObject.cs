using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class InteractableObject : MonoBehaviour
{
    public Dialogue dialogue;
    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("interactionAvailable");
            FindObjectOfType<InteractionManager>().EnableObject(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("interactionUnavailable");
            FindObjectOfType<InteractionManager>().DisableObject(this);
        }
    }
}
