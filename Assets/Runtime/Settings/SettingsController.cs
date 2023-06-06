using UnityEngine;
using UnityEngine.UI;
using CatCity;

[AddComponentMenu("Cat City/UI Options")]
public class SettingsUI : MonoBehaviour
{
    public GameSettings saveSettingsObject;

    #region Audio
    private AudioController audioController;

    public float GlobalVolume { get; private set; }

    public void ChangeVolume(Slider slider)
    {
        audioController.ChangeGlobalVolume(slider.value);
        GlobalVolume = slider.value;
    }
    #endregion

    #region Video
    public Dropdown dropResolutions;

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