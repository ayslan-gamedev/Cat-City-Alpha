namespace CatCity
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class VideoSettings
    {
        #region Resolutions
        private Resolution[] resolutions = new Resolution[0];
        private int currentResolution = 0;

        private void GetResolutions()
        {
            resolutions = Screen.resolutions;
        }

        private List<string> ResolutionsList()
        {
            List<string> preList = new List<string>();

            for(int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                preList.Add(option);

                if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolution = i;
                }
            }

            return preList;
        }

        public void SetResolutionsOptions(Dropdown dropdown)
        {
            GetResolutions();
            dropdown.ClearOptions();

            dropdown.AddOptions(ResolutionsList());
            dropdown.value = currentResolution;
            dropdown.RefreshShownValue();
        }

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

            currentResolution = resolutionIndex != null ? (int)resolutionIndex : dropdown.value;
            Resolution resolution = resolutionIndex != null ? resolutions[(int)resolutionIndex] : resolutions[currentResolution];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        #endregion

        #region Quality
        public void ChangeQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }
        #endregion

        #region Full Screen
        public void ChangeFullScreenMode(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }
        #endregion
    }

    public class AudioController
    {
        #region Global Volume
        public void ChangeGlobalVolume(float value)
        {
            AudioListener.volume = value;
        }
        #endregion

        public void ChangeVolume(AudioSource audio, float value)
        {
            audio.volume = value;
        }
    }
}