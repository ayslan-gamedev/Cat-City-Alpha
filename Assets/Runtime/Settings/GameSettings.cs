using UnityEngine;
using CatCity;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Save/Game Settings")]
public class GameSettings : ScriptableObject
{
    public MenuValues saveMenuValues;
}