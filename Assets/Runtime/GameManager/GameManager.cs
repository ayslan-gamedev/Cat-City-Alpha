using UnityEngine;
using UnityEngine.SceneManagement;

namespace CatCity
{
    [System.Serializable]
    public enum EditorVariables
    {
        GAME_MANAGER,
        Player,
        LoadScene
    }

    public class GameManager : MonoBehaviour
    {
        #region Language
        public Languages LanguageList;

        public Language CurrentLanguage { private set; get; }

        public void SeletLanguage(int LanguageIndex)
        {
            CurrentLanguage = LanguageList.languages.ToArray()[LanguageIndex];
        }
        #endregion

        public void Test()
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAA");
        }
    }
}