using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueSegment> DialogueSegments = new List<DialogueSegment>();
    public Dialogue endDialogue;

}

[System.Serializable]
public struct DialogueSegment
{
    public string dialogueText;
    public float dialogueDisplayTime;
    public List<DialogueChoice> dialogueChoices;
}

[System.Serializable]
    public struct DialogueChoice
    {
        
        public string dialogueChoiceText;
        public Dialogue followDialogue;
    }
    

