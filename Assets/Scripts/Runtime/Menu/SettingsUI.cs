using UnityEngine;
using UnityEngine.UI;
using CatCity;

public class SettingsUI : MonoBehaviour
{
    public Dropdown dropResolutions;

    #region Audio
    private AudioController audioController;
    
    public void VolumeSlider(Slider slider, AudioSource audioSource)
    {
        audioController.ChangeVolume(audioSource, slider.value);
    }

    public void GlobalVolume(Slider slider)
    {
        audioController.ChangeGlobalVolume(slider.value);
    }
    #endregion

    #region Video
    VideoSettings videoSettings;

    public void SetResolution(Dropdown dropdown)
    {
        videoSettings.ChangeResolution(dropdown, null);
    }

    public void SetQuatlity(Dropdown dropdown) 
    {
        videoSettings.ChangeQuality(dropdown.value);
    }

    public void SetFullScreen(bool toggle)
    {
        videoSettings.ChangeFullScreenMode(toggle);
    }
    #endregion

    private void Awake()
    {
        audioController = new AudioController();
        videoSettings = new VideoSettings();

        videoSettings.SetResolutionsOptions(dropResolutions);
    }
}