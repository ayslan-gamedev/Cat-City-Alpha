using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CatCity.DialogueElements;
using CatCity.Dialogue;
using TMPro;
using System;

[AddComponentMenu("Cat City/Dialogue/Controller")]
public class DialogueController : MonoBehaviour
{
    #region Initialize
    /// <summary>
    /// The dialogue file to be read
    /// </summary>
    public DialogueFolder CurrentDialogueFile { private get; set; }

    /// <summary>
    /// The Game object parent of all dialogue objects
    /// </summary>
    public GameObject theDialogueUIObect;

    /// <summary>
    /// The first line how will be read by script in dialogue folder
    /// </summary>
    public int FirstDialogue { private get; set; }

    /// <summary>
    /// Called externaly by any interaction script to starts the system, dialogue file required
    /// </summary>
    /// <param name="dialogueFile">The object dialogue in assets</param>
    public void StartDialogue(DialogueFolder dialogueFile)
    {
        CurrentDialogueFile = dialogueFile; // set current dialogue file defined by a external call

        LoadDialogueData(FirstDialogue); // load data of dialogue file
        
        StartUI(); // initialize UI

        WriteDialogue(true); // start the dialogue

        StartDialogueEvent();
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
        DialogueReader reader = new();

        // Gets values
        Lines = reader.DialogueLines(CurrentDialogueFile, nextId);
        choices = reader.DialogueChoices(CurrentDialogueFile, nextId);
        Events = reader.EventDialogue(CurrentDialogueFile, nextId);
    }
    #endregion

    #region Dialogue
    /// <summary>
    /// current lines of dialogue
    /// </summary>
    public DialogueLine[] Lines { get; private set; }

    UIDialogueObject dialogueUI; // generic class of the UI of dialogue

    /// <summary>
    /// The current dialogue line
    /// </summary>
    public int CurrentDalogueLineInUi { get; set; }

    /// <summary>
    /// the Text Mesh Pro object to show the dialgue text
    /// </summary>
    public TextMeshProUGUI UI_dialogueText;

    /// <summary>
    /// the Text Mesh Pro object to show the speaker of dialgue text
    /// </summary>
    public TextMeshProUGUI UI_speakerText;

    /// <summary>
    /// the image objecgt to show the image of speaker
    /// </summary>
    public Image UI_dialogueImage;

    /// <summary>
    /// write the UI Elements of dialogue
    /// </summary>
    public void SetDialogueUI()
    {
        // load a generic class of the UI of dialogue and sets the UI
        dialogueUI = new UIDialogueObject
        {
            // sets the UI
            dialogueText = UI_dialogueText,
            speakerText = UI_speakerText,
            protait = UI_dialogueImage
        };
    }

    DialogueWriter writer;
    
    /// <summary>
    /// write the main text of dialog
    /// </summary>
    public void WriteDialogue(bool ClearData)
    {
        writer = new DialogueWriter(); // load a generic class of the UI Dialogue Objects

        // sets the value in UI
        writer.WriteDialogue(WriteMode.Instant,Lines[CurrentDalogueLineInUi], dialogueUI, ClearData);

        DialogueEvent(); // call the event in dialogue if have
    }

    /// <summary>
    /// Called by player on UI when press the next button
    /// </summary>
    public void Button()
    {
        // verify if the dialogue text is total writed, and sets pass to a new dialogue line
        if(writer.WritingStatus() == 0)
        {
            CurrentDalogueLineInUi ++;
        }
        else
        {
            return;
        }
        
        if(CurrentDalogueLineInUi < Lines.Length) // verfiy if the new dialogue line exist
        {
            WriteDialogue(true); // write the new line
        }
        else
        {
            if(choices.Length > 0) // verfiy if the current dialogue have a choice
            {
                WriteChoiceUI(); // initialize the writer choices
            }
            else
            {
                EndDialogueEvent();
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
    /// <param name="choiceId">index of button selected by player</param>
    public void ButtonChoice(int choiceId)
    {
        int a = choices[choiceId].nextDialogueID;
        
        if(a == 109)
        {
            EndDialogueEvent();
            theDialogueUIObect.SetActive(false); // ends the script desactive UI
        }

        writerChoice.CloseChoices(uiChoice);
        CurrentDalogueLineInUi = 0;
        LoadDialogueData(a);
        WriteDialogue(true);
    }
    #endregion

    #region Event
    /// <summary>
    /// object manager dialogue events in scene
    /// </summary>
    public DialogueEvents sceneEvents;

    /// <summary>
    /// List of all current name events in scene
    /// </summary>
    public string[] Events { get; private set; } 

    /// <summary>
    /// Invoke the unity dialogue event if have 
    /// </summary>
    private void DialogueEvent()
    {
        for(int i = 0; i < Lines[CurrentDalogueLineInUi].@event.Count; i++)
        {
            string @event = Lines[CurrentDalogueLineInUi].@event[i]; // get event name from current line
    
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
    }

    /// <summary>
    /// Invoke the unity dialogue end event if have 
    /// </summary>
    private void EndDialogueEvent()
    {
        for(int i = 0; i < Events.Length; i++)
        {
            if(Events[i] != string.Empty)
            {
                if(sceneEvents != null)
                {
                    sceneEvents.CallEvent(Events[i]); // calls the event
                }
                else
                {
                    Debug.LogError("You need a scene dialogue events object to run events, please set in Dialogue Controller");
                }
            }
        }
    }

    private void StartDialogueEvent()
    {
        if(sceneEvents != null)
        {
            sceneEvents.CallEvent("StartDialogue"); // calls the event
        }
    }
    #endregion    
}