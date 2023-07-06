using System;
using System.Reflection;
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

        #region GameSettings
        private int m_quality;

        /// <summary>
        /// Current game quality
        /// </summary>
        public int GameQuality 
        { 
            get { return m_quality; }
            set
            {
                if(value != m_quality)
                {
                    QualitySettings.SetQualityLevel(value);
                    m_quality = value;
                }
                else
                {
                    Debug.LogFormat(value + "is not a valid Quality");
                }
            }
        }

        private int m_resolution;

        public int GameResolution
        {
            get { return m_resolution; }
            set
            {
                if(value != m_resolution)
                {
                    Resolution resolution = Screen.resolutions[value];
                    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
                    PlayerPrefs.SetInt("ResolutionIndex", m_resolution);
                    m_resolution = value;
                }
            }
        }

        #endregion
    }
}