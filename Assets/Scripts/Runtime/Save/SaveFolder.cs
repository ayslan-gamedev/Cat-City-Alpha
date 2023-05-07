using System.Collections.Generic;
using UnityEngine;
using CatCity.GameData;

[CreateAssetMenu(fileName = "Save Folder", menuName = "Player Data/Save Folder")]
public class SaveFolder : ScriptableObject
{
    public List<SaveFile> saveFile;
}

[CreateAssetMenu(fileName = "Save Data", menuName = "Player Data/Save File")]
public class SaveFile : ScriptableObject
{
    
}