using UnityEngine;
using CatCity.DialogueElements;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Dialogue Folder", menuName = "Dilaogue/Dialogue Folder")]
public class DialogueFolder : ScriptableObject
{
    public List<Dialogue> gameDialoguesList;
}