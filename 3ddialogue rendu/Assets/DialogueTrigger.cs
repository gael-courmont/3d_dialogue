using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Transform dialogueOptionParent;
    [SerializeField] private GameObject dialogueOptionButton;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject DialogueOptionContainer;
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField]
    private Dialogue dialogue;

    bool optionselected = false;
    public void start()
    {
        Debug.Log("test");
        StartCoroutine(DisplayDialogue());
        

    }

    public void optionSelectedChange(Dialogue selectedOption)
    {
        optionselected = true;
        dialogue = selectedOption;
        StartCoroutine(DisplayDialogue());
        
    }
    IEnumerator DisplayDialogue()
    {
        yield return null;
        foreach (var sentences in dialogue.DialogueSegments)
        {
            text.text = sentences.dialogueText;
            if (sentences.dialogueChoices.Count == 0)
            {
                yield return new WaitForSeconds(sentences.dialogueDisplayTime);
            }
            else
            {
                foreach (var option in sentences.dialogueChoices)
                {
                    DialogueOptionContainer.SetActive(true);
                    GameObject newButton = Instantiate(dialogueOptionButton, dialogueOptionParent);
                    newButton.GetComponent<DiologueOption>().setup(this,option.followDialogue,option.dialogueChoiceText);
                    Debug.Log(option.dialogueChoiceText);
                }

                while (!optionselected)
                {
                    yield return null;
                }
            }
        }
        DialogueOptionContainer.SetActive(false);
        if (dialogue.endDialogue)
        {
            dialogue = dialogue.endDialogue;

        }
        

    }

}
