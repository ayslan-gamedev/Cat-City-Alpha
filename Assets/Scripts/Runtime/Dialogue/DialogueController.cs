using UnityEngine;
using UnityEngine.UI;
using CatCity.Dialogue;
using CatCity.DialogueElements;
using TMPro;
using UnityEngine.EventSystems;

[AddComponentMenu("Cat City/Dialogue/Controller")]
public class DialogueController : MonoBehaviour
{
    #region Initialize
    private DialogueFolder currentDialogueFile; // the current dialogue file seted
    public GameObject theDialogueUIObect; 

    private const int firstDialogue = 0;

    /// <summary>
    /// Called externaly by any interaction script to starts the system, dialogue file required
    /// </summary>
    public void StartDialogue(DialogueFolder dialogueFile)
    {
        currentDialogueFile = dialogueFile; // set current dialogue file defined by a external call

        LoadDialogueData(firstDialogue); // load data of dialogue file
        
        StartUI(); // initialize UI

        WriteDialogue(); // start the dialogue
    }

    /// <summary>
    /// Initialize the UI start values
    /// </summary>
    private void StartUI()
    {
        theDialogueUIObect.SetActive(true); // active dialogue UI
        
        // set the dialogue values on UI, initializing the scripiting
        SetDialogueUI();
        SetChoiceUI();
    }

    /// <summary>
    /// Get the dialogue data on dialogue folder using DialogueDataReader
    /// </summary>
    private void LoadDialogueData(int nextId)
    {
        DialogueReader reader = new DialogueReader();

        // Gets values
        lines = reader.dialogueLines(currentDialogueFile, nextId);
        choices = reader.dialogueChoices(currentDialogueFile, nextId);
    }
    #endregion

    #region Dialogue
    public TextMeshProUGUI UI_dialogueText, UI_speakerText;
    public Image UI_dialogueImage;

    DialogueLine[] lines; // current lines of dialogue
    UIDialogueObject dialogueUI; // generic class of the UI of dialogue

    private int currentDalogueLineInUi = 0;

    /// <summary>
    /// write the UI Elements of dialogue
    /// </summary>
    private void SetDialogueUI()
    {
        dialogueUI = new UIDialogueObject(); // load a generic class of the UI of dialogue

        // sets the UI
        dialogueUI.dialogueText = UI_dialogueText;
        dialogueUI.speakerText = UI_speakerText;
        dialogueUI.protait = UI_dialogueImage;
    }

    DialogueWriter writer;
    
    /// <summary>
    /// called to write the main text of dialog
    /// </summary>
    void WriteDialogue()
    {
        writer = new DialogueWriter(); // load a generic class of the UI Dialogue Objects

        // sets the value in UI
        writer.WriteDialogue(WriteMode.Instant,lines[currentDalogueLineInUi], dialogueUI);

        SetDialogueEvent(); // call the event in dialogue if have
    }

    /// <summary>
    /// Called by player on UI when press the next button
    /// </summary>
    public void Button()
    {
        // verify if the dialogue text is total writed, and sets pass to a new dialogue line
        currentDalogueLineInUi = writer.WritingStatus() == 0 ? currentDalogueLineInUi + 1 : 0;

        if(currentDalogueLineInUi < lines.Length) // verfiy if the new dialogue line exist
        {
            WriteDialogue(); // write the new line
        }
        else
        {
            if(choices.Length > 0) // verfiy if the current dialogue have a choice
            {
                WriteChoiceUI(); // initialize the writer choices
            }
            else
            {
                theDialogueUIObect.SetActive(false); // ends the script desactive UI
            }
        }
    }
    #endregion

    #region Choice
    public GameObject choicesObject;
    public GameObject[] buttonObjects;
    
    private TextMeshProUGUI[] UIchoiceText; // the text of buttons in UI

    Choice[] choices; // current Choices from dialog file
    UIChoicesObject uiChoice; // generic class of the UI of choices

    /// <summary>
    /// write the values of uiChoices
    /// </summary>
    private void SetChoiceUI()
    {
        uiChoice = new UIChoicesObject(); // set a generic class of Choices UI
        UIchoiceText = new TextMeshProUGUI[buttonObjects.Length]; // define the length of textmeshpro array 

        // sets the ui object to generic class
        for(int i = 0; i < buttonObjects.Length; i++)
        {
            UIchoiceText[i] = buttonObjects[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        // sets the UI values on screen
        uiChoice.buttonObeject = buttonObjects;
        uiChoice.choiceText = UIchoiceText;
        uiChoice.choicesObject = choicesObject;
    }

    ChoicesWriter writerChoice;

    /// <summary>
    /// write the choices in UI
    /// </summary>
    private void WriteChoiceUI()
    {
        writerChoice = new ChoicesWriter(); // load a generic class of the UI Choices Object

        // sets the value in UI
        writerChoice.WriteChoice(choices, uiChoice);
    }

    /// <summary>
    /// Get the value of choice selected by player in UI
    /// </summary>
    public void ButtonChoice(int choiceId)
    {
        int a = choices[choiceId].nextDialogueID;
        writerChoice.CloseChoices(uiChoice);
        currentDalogueLineInUi = 0;
        LoadDialogueData(a);
        WriteDialogue();
    }
    #endregion

    #region Event
    public DialogueEvents sceneEvents; // object manager dialogue events in scene

    /// <summary>
    /// Invoke the unity dialogue in event if have 
    /// </summary>
    private void SetDialogueEvent()
    {
        string @event = lines[currentDalogueLineInUi].callEvent; // get event name from current line
    
        // checks if have some event be called in current line
        if(@event != string.Empty)
        {
            if(sceneEvents != null)
            {
                sceneEvents.CallEvent(@event); // calls the event
            }
            else
            {
                Debug.LogError("You need a scene dialogue events object to run events, please set in Dialogue Controller");
            }
        }
    }
    #endregion
}