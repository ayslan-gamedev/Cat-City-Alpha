using CatCity;
using UnityEngine;

[CreateAssetMenu(fileName = "Save Object", menuName = "Save/Save Object")]
public class Save : ScriptableObject
{
    public SceneValues sceneValues;
    public PlayerData playerData;
    //public MenuValues menuValues;
}