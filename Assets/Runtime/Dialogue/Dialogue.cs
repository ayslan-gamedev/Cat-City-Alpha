using CatCity.DialogueElements;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "Dilaogue/Dialogue Object")]
public class Dialogue : ScriptableObject
{
    public List<GameDialogue> gameDialogues;
}