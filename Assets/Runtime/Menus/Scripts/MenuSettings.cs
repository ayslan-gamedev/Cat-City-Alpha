using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{

    private int currentQualityIndex;
    private int currentResolutionIndex;

    private void Start()
    {
        // Armazena as configurações atuais
        currentQualityIndex = QualitySettings.GetQualityLevel();
        currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", Screen.resolutions.Length - 1);
    }



    #region VIDEO

    public void SetResolution()
    {

    }

    public void SetQuality()
    {

    }

    private bool m_fullScreen;

    /// <summary>
    /// Set the game FullScreen
    /// </summary>
    public bool FullScreen 
    {
        get { return m_fullScreen; }
        set
        {
            m_fullScreen = value;
            Screen.fullScreen = value;
        }
    }
    #endregion

    #region AUDIO

    /// <summary>
    /// Play any sund in game
    /// </summary>
    public bool MuteAudio { get; set; }

    /// <summary>
    /// Change the volume of a different sound
    /// </summary>
    /// <param name="slider">the Slider</param>
    public void SetVolume(Slider slider)
    {

    }

    #endregion
}