using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "MyObjects/Dialogue")] 
public class Dialogue : ScriptableObject
{
    public string[] dialogueLines;
}
