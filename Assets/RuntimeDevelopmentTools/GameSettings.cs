using UnityEngine;

namespace CatCity.Editor
{
    [CreateAssetMenu(fileName = "EditorSettings", menuName = "EditorSettings")]
    public class GameSettings : ScriptableObject
    {
        public bool DevMode;
        public int devID;
    }
}