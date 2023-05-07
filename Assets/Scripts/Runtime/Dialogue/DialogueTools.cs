namespace CatCity.Dialogue
{
    using CatCity.DialogueElements;
    using System.Threading.Tasks;
    using UnityEngine;

    #region Reader
    public class DialogueReader
    {
        public const string GAME_MANAGER = "GameManager";
        private Language currentLanguage;

        public void GetLanguage()
        {
            GameManager languageSettings;

            if(GameObject.Find(GAME_MANAGER))
            {
                languageSettings = GameObject.Find(GAME_MANAGER).GetComponent<GameManager>();
                currentLanguage = languageSettings.currentLanguage;
            }
            else
            {
                currentLanguage = new Language();
                currentLanguage.name = "default";
                currentLanguage.index = 0;
            }
        }

        public DialogueLine[] dialogueLines(global::DialogueFolder dialogueFile, int dialogueId)
        {
            GetLanguage();
            return dialogueFile.gameDialoguesList.ToArray()[currentLanguage.index].gameDialogues.ToArray()[dialogueId].linesList.ToArray();
        }

        public Choice[] dialogueChoices(global::DialogueFolder dialogueFile, int dialogueId)
        {
            GetLanguage();
            return dialogueFile.gameDialoguesList.ToArray()[currentLanguage.index].gameDialogues.ToArray()[dialogueId].choicesList.ToArray();
        }
    }
    #endregion

    #region Writer
    public enum WriteMode { Instant, BySpeed }

    public class DialogueWriter
    {
        public void WriteDialogue(WriteMode writeMode, DialogueLine line, UIDialogueObject dialogueUI)
        {
            ClearData(dialogueUI);

            switch(writeMode)
            {
                case WriteMode.Instant:
                    WriteInstant(line, dialogueUI);
                    break;

                case WriteMode.BySpeed:
                    WriteBySpeed(line, dialogueUI);
                    break;
            }
        }

        private void ClearData(UIDialogueObject dialogueUI)
        {
            dialogueUI.dialogueText.text = string.Empty;
            dialogueUI.speakerText.text = string.Empty;
        }

        #region BySpeed
        private static protected byte writing;

        public byte WritingStatus()
        {
            return writing;
        }

        private void WriteBySpeed(DialogueLine line, UIDialogueObject dialogueUI)
        {
            if(writing == 0)
            {
                dialogueUI.speakerText.text = line.speaker;

                SetDelay(100);
                _ = Writer(line, dialogueUI);
            }
            else
            {
                SetDelay(5);
            }
        }

        private protected static float delay;

        private static void SetDelay(float newDelay)
        {
            delay = newDelay;
        }

        static async Task Writer(DialogueLine line, UIDialogueObject dialogueUI)
        {
            writing = 1;

            foreach(char @char in line.text)
            {
                dialogueUI.dialogueText.text += @char;
                await Task.Delay((int)(delay * Time.timeScale));
            }

            writing = 0;
        }
        #endregion

        private void WriteInstant(DialogueLine line, UIDialogueObject dialogueUI)
        {
            dialogueUI.protait.sprite = line.protait;
            dialogueUI.speakerText.text = line.speaker;
            dialogueUI.dialogueText.text = line.text;
        }
    }

    public class ChoicesWriter
    {
        public void WriteChoice(Choice[] choices, UIChoicesObject choiceUI)
        {
            choiceUI.choicesObject.SetActive(true);

            for(int i = 0; i < choices.Length; i++)
            {
                choiceUI.buttonObeject[i].SetActive(true);
                choiceUI.choiceText[i].text = choices[i].text;
            }
        }

        public void CloseChoices(UIChoicesObject choiceUI)
        {
            for(int i = 0; i < choiceUI.buttonObeject.Length; i++)
            {
                choiceUI.buttonObeject[i].SetActive(false);
                choiceUI.choiceText[i].text = string.Empty;
            }

            choiceUI.choicesObject.SetActive(false);
        }
    }
    #endregion
}