using System;
using UnityEngine;

namespace CatCity
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Current Audio Settings
        /// </summary>
        public AudioSettings GameAudioSettings { get; set; } = new()
        {
            EnableSound = true,
            MainVolume = 1,
            MusicVolume = 1,
            SoundEffectVolume = 1
        };

        /// <summary>
        /// Set a new volume to GameAudioSettings
        /// </summary>
        /// <param name="type"></param>
        /// <param name="volume"></param>
        public void SetVolume(AudioType type, float volume)
        {
            switch(type) 
            {
                case AudioType.Default:
                    GameAudioSettings.MainVolume = volume;
                    break;

                case AudioType.Music:
                    GameAudioSettings.MusicVolume = volume;
                    break;

                case AudioType.SoundEffect:
                    GameAudioSettings.SoundEffectVolume = volume;
                    break;
            }

            UpdateSceneAudio();
        }

        /// <summary>
        /// Set a new volume to GameAudioSettings
        /// </summary>
        /// <param name="audioOn"></param>
        public void SetVolume(bool audioOn)
        {
            GameAudioSettings.EnableSound = audioOn;

            UpdateSceneAudio();
        }

        private void UpdateSceneAudio()
        {
            AudioController[] audiosInScene = FindObjectsOfType<AudioController>();
            for(int i = 0; i < audiosInScene.Length; i++)
            {
                audiosInScene[i].SetLocalVolume();
            }
        }

        #region Language
        public Languages LanguageList;

        public Language CurrentLanguage;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            UpdateSceneAudio();
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
    }

    [System.Serializable]
    public class AudioSettings
    {
        public bool EnableSound;
        [Range(0, 1)] public float MainVolume;
        [Range(0, 1)] public float MusicVolume;
        [Range(0, 1)] public float SoundEffectVolume;
    }

    public enum AudioType
    {
        Default = 0,
        Music = 1,
        SoundEffect = 3
    }
}