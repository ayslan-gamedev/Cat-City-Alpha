using CatCity.Player;
using UnityEngine;

[CreateAssetMenu(fileName = "Save Player Data", menuName = "Player Data/Player")]
public class SaveData : ScriptableObject
{
    [SerializeField]
    public Vector2 position;

    [SerializeField]
    public PlayerMovement mode;
}