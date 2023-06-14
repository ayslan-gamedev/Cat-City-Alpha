using UnityEngine;
using TMPro;

public class MultipleTextsDialogue : MonoBehaviour
{
    public DialogueController dialogueController;
    public TextMeshProUGUI[] textFields;

    public DialogueFolder DialogueFolder;

    void Awake()
    {
        dialogueController.StartDialogue(DialogueFolder);

        for(int i = 0; i < textFields.Length && dialogueController.Lines.Length > i && textFields[i] != null; i++)
        {
            dialogueController.UI_dialogueText = textFields[i];

            dialogueController.SetDialogueUI();
            dialogueController.WriteDialogue(false);
            
            dialogueController.CurrentDalogueLineInUi++;
        }
    }
}
