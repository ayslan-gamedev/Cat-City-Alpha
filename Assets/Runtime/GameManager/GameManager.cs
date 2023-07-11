using UnityEngine;
using CatCity;

public class GameManager : MonoBehaviour
{
    // Called in the first freame in scene
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);

        DontDestroyOnLoad(gameObject);

        if(gameSettings != null)
        {
            LoadSettingsData();
        }
    }

    /// <summary>
    /// Name of current game scene
    /// </summary>
    public string CurrentGameScene { get; set; }

    #region Settings
    public GameSettings gameSettings;
    
    /// <summary>
    /// Load all settings data 
    /// </summary>
    private void LoadSettingsData()
    {
        RuntimeAudioSettings = gameSettings.audioSettings;
        UpdateSceneAudio();

        //RuntimeVideoSettings = gameSettings.videoSettings;
        //UpdateGameVideoSettings();

        if(gameSettings.language != null)
        {
            RuntimeLanguage = gameSettings.language;
        }
    }

    /// <summary>
    /// Save all settings data
    /// </summary>
    public void SaveSettingsData()
    {
        gameSettings.videoSettings = RuntimeVideoSettings;
        gameSettings.audioSettings = RuntimeAudioSettings;
        gameSettings.language = RuntimeLanguage;
    }
    
    #region Audio
    private CatCity.AudioSettings run_audioSettings = new()
    {
        EnableSound = true,
        MainVolume = 1,
        MusicVolume = 1,
        SoundEffectVolume = 1
    };

    /// <summary>
    /// Current Audio Settings
    /// </summary>
    public CatCity.AudioSettings RuntimeAudioSettings 
    {
        get { return run_audioSettings; }
        set 
        {
            run_audioSettings = value;
            SaveSettingsData();
        } 
    }

    /// <summary>
    /// Set a new volume to GameAudioSettings
    /// </summary>
    /// <param name="type"></param>
    /// <param name="volume"></param>
    public void SetVolume(CatCity.AudioType type, float volume)
    {
        switch(type)
        {
            case CatCity.AudioType.Default:
                RuntimeAudioSettings.MainVolume = volume;
                break;

            case CatCity.AudioType.Music:
                RuntimeAudioSettings.MusicVolume = volume;
                break;

            case CatCity.AudioType.SoundEffect:
                RuntimeAudioSettings.SoundEffectVolume = volume;
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
        RuntimeAudioSettings.EnableSound = audioOn;

        UpdateSceneAudio();
    }

    /// <summary>
    /// Update all audios volumes in scene
    /// </summary>
    private void UpdateSceneAudio()
    {
        AudioController[] audiosInScene = FindObjectsOfType<AudioController>();
        for(int i = 0; i < audiosInScene.Length; i++)
        {
            audiosInScene[i].SetLocalVolume();
        }
    }
    #endregion

    #region Video
    private VideoSettings run_videoSettings = new()
    {
        EnabledFullScreen = true,
        EnabledPosprocessing = true,
        EnabledParticles = true,
        resolution = new ScreenResolution(0, 0),
        Quality = 0
    };

    /// <summary>
    /// Current Video Settings
    /// </summary>
    public VideoSettings RuntimeVideoSettings 
    {
        get
        {
            return run_videoSettings;
        }
        set
        {
            run_videoSettings = value;
            SaveSettingsData();
        }
    }

    private void UpdateGameVideoSettings()
    {
        Screen.SetResolution(RuntimeVideoSettings.resolution.w, RuntimeVideoSettings.resolution.h, RuntimeVideoSettings.EnabledFullScreen);
        QualitySettings.SetQualityLevel(RuntimeVideoSettings.Quality, true);
    }
    #endregion

    #region Language
    public Languages LanguageList;

    private Language currentLanguage;

    /// <summary>
    /// Current language in runtime game
    /// </summary>
    public Language RuntimeLanguage
    {
        get { return currentLanguage; }
        set
        {
            currentLanguage = value;
            SaveSettingsData();
        }
    }

    /// <summary>
    /// Change the language
    /// </summary>
    /// <param name="LanguageIndex"></param>
    public void SetGameLanguage(int LanguageIndex)
    {
        if(LanguageList != null)
        {
            RuntimeLanguage = LanguageList.languages.ToArray()[LanguageIndex];
        }
        else
        {
            Debug.LogWarning("lanaguage List not seted!!");
        }
    }
    #endregion
    #endregion
}