using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Dictionary<InteractableObject, bool> interactableObjects;

    //Define dictionary
    public InteractionManager()
    {
        interactableObjects = new Dictionary<InteractableObject, bool>();
    }

    //Add interactable object to dictionary
    public void EnableObject(InteractableObject interactableObject)
    {
        if(!interactableObjects.ContainsKey(interactableObject)) 
        {
            interactableObjects.Add(interactableObject, true);
        }
        else
        { interactableObjects[interactableObject] = true;}
    }

    //Disable interactable object in dictionary
    public void DisableObject(InteractableObject interactableObject)
    {
        if (interactableObjects.ContainsKey(interactableObject))
        {
            interactableObjects[interactableObject] = false;
            
        }
    }

    //Get the first interaction available in dictionary
    public InteractableObject GetActiveInteraction()
    {
        return interactableObjects.FirstOrDefault(x => x.Value == true).Key;
    }
}
