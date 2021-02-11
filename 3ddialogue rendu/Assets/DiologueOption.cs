using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiologueOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOption;
    private DialogueTrigger dialogueTrigger;

    private Dialogue dialogueObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup(DialogueTrigger _dialogueTrigger,Dialogue _dialogue,string dialogueText)
    {
        dialogueTrigger = _dialogueTrigger;
        dialogueObject = _dialogue;
        textOption.text = dialogueText;
    }
    
    public void selectOption()
    {
       dialogueTrigger.optionSelectedChange(dialogueObject); 
    }
}
