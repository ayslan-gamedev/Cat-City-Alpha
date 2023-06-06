using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Folder", menuName = "Dilaogue/Dialogue Folder")]
public class DialogueFolder : ScriptableObject
{
    public List<Dialogue> gameDialoguesList;
}