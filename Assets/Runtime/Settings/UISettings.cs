using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatCity
{
    public class VideoSettings
    {
        #region Resolutions
        /// <summary>
        /// Array of resolutions
        /// </summary>
        private Resolution[] resolutions = new Resolution[0];

        /// <summary>
        /// current resolution running in game
        /// </summary>
        public int CurrentResolution { get; private set; }

        /// <summary>
        /// Get arry of resolutions
        /// </summary>
        private void GetResolutions()
        {
            resolutions = Screen.resolutions;
        }

        /// <summary>
        /// List with all resolutions options
        /// </summary>
        /// <returns>resolutions options</returns>
        private List<string> ResolutionsList()
        {
            List<string> preList = new List<string>();

            for(int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                preList.Add(option);

                if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    CurrentResolution = i;
                }
            }

            return preList;
        }

        /// <summary>
        /// Set resolutions options in scene
        /// </summary>
        /// <param name="dropdown">unity dropdown to get the options</param>
        public void SetResolutionsOptions(Dropdown dropdown)
        {
            GetResolutions();
            dropdown.ClearOptions();

            dropdown.AddOptions(ResolutionsList());
            dropdown.value = CurrentResolution;
            dropdown.RefreshShownValue();
        }

        /// <summary>
        /// Change the resolution
        /// </summary>
        /// <param name="dropdown">unity dropdown with resolutions options</param>
        /// <param name="resolutionIndex">the resolution selected correspondence to array of resolutions</param>
        public void ChangeResolution(Dropdown dropdown, int? resolutionIndex)
        {
            if(resolutions.Length == 0)
            {
                GetResolutions();
            }

            if(resolutionIndex == null && dropdown.options.Count == 0)
            {
                SetResolutionsOptions(dropdown);
                ChangeResolution(null, null);
            }

            CurrentResolution = resolutionIndex != null ? (int)resolutionIndex : dropdown.value;
            Resolution resolution = resolutionIndex != null ? resolutions[(int)resolutionIndex] : resolutions[CurrentResolution];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        #endregion

        #region Quality
        /// <summary>
        /// change the qaulity of game
        /// </summary>
        /// <param name="qualityIndex">value of quality correspondence to quality game options</param>
        public void ChangeQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }
        #endregion

        #region Full Screen
        /// <summary>
        /// Set fullscreen
        /// </summary>
        /// <param name="isFullscreen">Fullscreen ON/OFF</param>
        public void ChangeFullScreenMode(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }
        #endregion
    }

    public class AudioController
    {
        #region Global Volume
        /// <summary>
        /// Change the global Volume
        /// </summary>
        /// <param name="value">volume</param>
        public void ChangeGlobalVolume(float value)
        {
            AudioListener.volume = value;
        }
        #endregion

        /// <summary>
        /// Change the volume of a audio
        /// </summary>
        /// <param name="audio"></param>
        /// <param name="value"></param>
        public void ChangeVolume(AudioSource audio, float value)
        {
            audio.volume = value;
        }
    }
}