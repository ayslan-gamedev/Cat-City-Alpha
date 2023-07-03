using System.Threading.Tasks;
using UnityEngine;
using CatCity.DialogueElements;
using CatCity;

namespace CatCity.Dialogue
{
    #region Reader
    public class DialogueReader
    {
        private Language currentLanguage;

        /// <summary>
        /// Set the dialogue language
        /// </summary>s
        public void GetLanguage()
        {
            try
            {
                currentLanguage = Object.FindObjectOfType<GameManager>().GetComponent<GameManager>().CurrentLanguage;
            }
            catch
            {
                currentLanguage = new Language
                {
                    name = "default",
                    index = 0
                };
            }
        }

        /// <summary>
        /// Returns the lines of dialogue
        /// </summary>
        /// <param name="dialogueFile">The object dialogue in assets</param>
        /// <param name="dialogueId">the id of line dialogue inside the file</param>
        /// <returns>the lines of dialogue</returns>
        public DialogueLine[] DialogueLines(DialogueFolder dialogueFile, int dialogueId)
        {
            GetLanguage();
            return dialogueFile.gameDialoguesList.ToArray()[currentLanguage.index].gameDialogues.ToArray()[dialogueId].linesList.ToArray();
        }

        /// <summary>
        /// Returns the current choices of line dialogue 
        /// </summary>
        /// <param name="dialogueFile">The object dialogue in assets</param>
        /// <param name="dialogueId">the id of line dialogue inside the file</param>
        /// <returns>the current choices of line dialogue</returns>
        public Choice[] DialogueChoices(DialogueFolder dialogueFile, int dialogueId)
        {
            GetLanguage();
            return dialogueFile.gameDialoguesList.ToArray()[currentLanguage.index].gameDialogues.ToArray()[dialogueId].choicesList.ToArray();
        }

        /// <summary>
        /// Returns the final event of dialogue cell
        /// </summary>
        /// <param name="dialogueFile">The object dialogue in assets</param>
        /// <param name="dialogueId">the id of line dialogue inside the file</param>
        /// <returns>the final event of dialogue cell</returns>
        public string[] EventDialogue(DialogueFolder dialogueFile, int dialogueId)
        {
            GetLanguage();
            return dialogueFile.gameDialoguesList.ToArray()[currentLanguage.index].gameDialogues.ToArray()[dialogueId].@event.ToArray();
        }
    }
    #endregion

    #region Writer
    /// <summary>
    /// The options to write the text in screen
    /// </summary>
    public enum WriteMode { Instant, BySpeed }

    public class DialogueWriter
    {
        /// <summary>
        /// Write the text in screen
        /// </summary>
        /// <param name="writeMode">Select the form to write the text</param>
        /// <param name="line">Text to Write</param>
        /// <param name="dialogueUI">The text field in unity</param>
        public void WriteDialogue(WriteMode writeMode, DialogueLine line, UIDialogueObject dialogueUI, bool? cleanData)
        {
            if(cleanData != null && cleanData == true)
            {
                ClearData(dialogueUI);
            }

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

        /// <summary>
        /// Clear the text in screen before show the next text
        /// </summary>
        /// <param name="dialogueUI">The text field in unity</param>
        public void ClearData(UIDialogueObject dialogueUI)
        {
            dialogueUI.dialogueText.text = string.Empty;
            dialogueUI.speakerText.text = string.Empty;
        }

        #region BySpeed
        private static protected byte writing;

        /// <summary>
        /// The Write stats
        /// </summary>
        /// <returns>Return true if the text is not complety</returns>
        public byte WritingStatus()
        {
            return writing;
        }

        /// <summary>
        /// Write the text in screen
        /// </summary>
        /// <param name="line">Text to Write</param>
        /// <param name="dialogueUI">Object with the ui objects in screen</param>
        private void WriteBySpeed(DialogueLine line, UIDialogueObject dialogueUI)
        {
            if(writing == 0)
            {

                SetDelay(100);
                _ = Writer(line, dialogueUI);
            }
            else
            {
                SetDelay(5);
            }
        }

        /// <summary>
        /// the current delay to write the text
        /// </summary>
        private protected static float delay;

        /// <summary>
        /// Set the current delay to write the text
        /// </summary>
        /// <param name="newDelay">value to delay</param>
        private static void SetDelay(float newDelay)
        {
            delay = newDelay;
        }

        /// <summary>
        /// Write the text using delay, (NOT USING the game time!!)
        /// </summary>
        /// <param name="line"></param>
        /// <param name="dialogueUI"></param>
        static async Task Writer(DialogueLine line, UIDialogueObject dialogueUI)
        {
            dialogueUI.protait.sprite = line.protait;
            dialogueUI.speakerText.text = line.speaker;

            writing = 1;

            foreach(char @char in line.text)
            {
                dialogueUI.dialogueText.text += @char;
                await Task.Delay((int)(delay * Time.timeScale));
            }

            writing = 0;
        }
        #endregion

        /// <summary>
        /// Write the Text
        /// </summary>
        /// <param name="line">Text to Write</param>
        /// <param name="dialogueUI">Object with the ui objects in screen</param>
        private void WriteInstant(DialogueLine line, UIDialogueObject dialogueUI)
        {
            if(line.protait)
            {
                dialogueUI.protait.sprite = line.protait;
            }
            
            dialogueUI.speakerText.text = line.speaker;
            dialogueUI.dialogueText.text = line.text;
        }
    }

    public class ChoicesWriter
    {
        /// <summary>
        /// Write the choices in screen
        /// </summary>
        /// <param name="choices">text of choices</param>
        /// <param name="dialogueUI">Object with the ui objects in screen</param>
        public void WriteChoice(Choice[] choices, UIChoicesObject choiceUI)
        {
            choiceUI.choicesObject.SetActive(true);

            for(int i = 0; i < choices.Length; i++)
            {
                choiceUI.buttonObeject[i].SetActive(true);
                choiceUI.choiceText[i].text = choices[i].text;
            }
        }

        /// <summary>
        /// Clear the text in screen before show the next text
        /// </summary>
        /// <param name="dialogueUI">The object field of choices in unity</param>
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