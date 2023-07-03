using UnityEngine;
using UnityEngine.SceneManagement;

namespace CatCity
{
    public class GameManager : MonoBehaviour
    {
        #region Language
        public Languages LanguageList;

        public Language CurrentLanguage;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("a");
        }

        public void SetGameLanguage(int LanguageIndex)
        {
            if(LanguageList != null)
            {
                CurrentLanguage = LanguageList.languages.ToArray()[LanguageIndex];
            }
            else
            {
                Debug.LogWarning("lanaguage List not seted!!");
            }

        }
        #endregion

        public void Test()
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAA");
        }
    }
}