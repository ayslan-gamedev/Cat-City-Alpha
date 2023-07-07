using CatCity;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;

public class MenuSettings : MonoBehaviour
{
    #region Initialize
    private void Start()
    {
        SetGameManager();

        SetCurrentAudioValues();
        SetCurrentVideoValues();
    }

    [SerializeField] private GameObject GameManagerPreFab;
    private GameManager m_manager;

    /// <summary>
    /// Found game manager in scene
    /// </summary>
    private void SetGameManager()
    {
        try
        {
            m_manager = FindAnyObjectByType<GameManager>();
        }
        catch
        {
            if(GameManagerPreFab != null)
            {
                Debug.LogWarning("GAME MANAFER NOT FOUND!\n A new manager has ben created to debugging mode");

                Instantiate(GameManagerPreFab);
                SetGameManager();
                return;
            }

            Debug.LogWarning("GAME MANAGER NOT FOUND!"); return;
        }
    }
    #endregion

    #region Audio
    public Slider MainSlider, MusicSlider, SoundEffecSlider;
    public Toggle audioToggle;

    /// <summary>
    /// Set the current values in Ui based in data on game manager
    /// </summary>
    public void SetCurrentAudioValues()
    {
        if(m_manager != null)
        {
            MainSlider.value = m_manager.RuntimeAudioSettings.MainVolume;
            MusicSlider.value = m_manager.RuntimeAudioSettings.MusicVolume;
            SoundEffecSlider.value = m_manager.RuntimeAudioSettings.SoundEffectVolume;

            audioToggle.isOn = m_manager.RuntimeAudioSettings.EnableSound;
        }
        else
        {
            SetGameManager();
        }
    }

    /// <summary>
    /// Change the Dafault Volume of game based in a slider
    /// </summary>
    /// <param name="theSlider">slider volume</param>
    public void ChangeMainVolume()
    {
        m_manager.SetVolume(CatCity.AudioType.Default, MainSlider.value);
    }

    /// <summary>
    /// Change the Music Volume of game based in a slider
    /// </summary>
    /// <param name="theSlider">slider volume</param>
    public void ChangeMusicVolume()
    {
        m_manager.SetVolume(CatCity.AudioType.Music, MusicSlider.value);
    }

    /// <summary>
    /// Change the Sound Effect Volume of game based in a slider
    /// </summary>
    /// <param name="theSlider">slider volume</param>
    public void ChangeSoundEffectVolume()
    {
        m_manager.SetVolume(CatCity.AudioType.SoundEffect, SoundEffecSlider.value);
    }

    /// <summary>
    /// Turn ON/OFF all volumes
    /// </summary>
    /// <param name="toggle">button enabled</param>
    public void ChangeAudioEnabled()
    {
        m_manager.SetVolume(audioToggle.isOn);
    }
    #endregion

    #region Video
    public TMP_Dropdown dropResolutions;
    public TMP_Dropdown dropQualitys;

    private List<string> Resolutions()
    {
        List<string> resolutions = new List<string>();
        Resolution[] Listresolutions = Screen.resolutions;

        foreach(Resolution r in Listresolutions)
        {
            resolutions.Add(string.Format("{0} X {1}", r.width, r.height));
        }

        return resolutions;
    }

    private List<string> Qualitys()
    {
        return QualitySettings.names.ToList();
    }

    private void SetCurrentVideoValues()
    {
        dropResolutions.AddOptions(Resolutions());
        dropResolutions.value = Resolutions().Count - 1;

        dropQualitys.AddOptions(Qualitys());
        dropQualitys.value = QualitySettings.GetQualityLevel();
    }

    /// <summary>
    /// Set the selected Resolution
    /// </summary>
    public void SetResolution()
    {
        string[] res = Resolutions()[dropResolutions.value].Split('X');
        int w = Convert.ToInt16(res[0].Trim()); 
        int h = Convert.ToInt16(res[1].Trim());
        
        Screen.SetResolution(w, h, Screen.fullScreen);

        m_manager.RuntimeVideoSettings.resolution = new ScreenResolution(w, h);
    }

    /// <summary>
    /// Set the selected Quality
    /// </summary>
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropQualitys.value, true);
        m_manager.RuntimeVideoSettings.Quality = dropQualitys.value;
    }

    public Toggle fullScreeToggle;

    /// <summary>
    /// Turn ON/OFF WindowsMode
    /// </summary>
    public void SetWindowMode()
    {
        Screen.fullScreen = fullScreeToggle.isOn;
        m_manager.RuntimeVideoSettings.EnabledFullScreen = fullScreeToggle.isOn;
    }

    public Toggle PostProcessingToggle;

    /// <summary>
    /// Turn ON/OFF PostProcessing
    /// </summary>
    public void SetPostProcessing()
    {
        Screen.fullScreen = PostProcessingToggle.isOn;
        m_manager.RuntimeVideoSettings.EnabledPosprocessing = PostProcessingToggle.isOn;
    }

    public Toggle ParticlesToggle;

    /// <summary>
    /// Turn ON/OFF particles
    /// </summary>
    public void SetParticles()
    {
        Screen.fullScreen = ParticlesToggle.isOn;
        m_manager.RuntimeVideoSettings.EnabledParticles = ParticlesToggle.isOn;

    }
    #endregion

    #region Language
    public ManagerUltilitys m_ultilitys;

    private int language;

    /// <summary>
    /// Set a new language to load after restart scene
    /// </summary>
    /// <param name="sceneToLoad"></param>
    public void SetNewLanguege(int language)
    {
        this.language = language;
    }

    /// <summary>
    /// Restart scene
    /// </summary>
    public void Confirm()
    {
        m_ultilitys.SetNewLanguage(language);
        m_ultilitys.LoadNewScene(m_manager.CurrentGameScene);
    }
    #endregion
}