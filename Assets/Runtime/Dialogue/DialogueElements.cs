using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace CatCity.DialogueElements
{
    [System.Serializable]
    public class GameDialogue
    {
        public List<DialogueLine> linesList;
        public List<Choice> choicesList;
        public List<string> @event;
    }

    [System.Serializable]
    public class DialogueLine
    {
        public string speaker;
        public string text;
        public Sprite protait;
        public List<string> @event;
    }

    [System.Serializable]
    public class Choice
    {
        public string text;
        public int nextDialogueID;
    }

    [System.Serializable]
    public class DialogueEvent
    {
        public string eventName;
        public UnityEvent @event;
    }
    
    #region UI Objects
    public class UIDialogueObject
    {
        public TextMeshProUGUI dialogueText;
        public TextMeshProUGUI speakerText;
        public Image protait;
    }

    public class UIChoicesObject
    {
        public GameObject choicesObject;

        public TextMeshProUGUI[] choiceText;
        public GameObject[] buttonObeject;
    }
    #endregion
}