using CatCity;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    #region Initialize
    private void Awake()
    {
        SetGameManager();
        SetCurrentValues();
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
    public void SetCurrentValues()
    {
        if(m_manager != null)
        {
            MainSlider.value = m_manager.GameAudioSettings.MainVolume;
            MusicSlider.value = m_manager.GameAudioSettings.MusicVolume;
            SoundEffecSlider.value = m_manager.GameAudioSettings.SoundEffectVolume;

            audioToggle.enabled = m_manager.GameAudioSettings.EnableSound;
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
        if(m_manager != null)
        {
            m_manager.SetVolume(CatCity.AudioType.Default, MainSlider.value);
        }
        else
        {
            SetGameManager();
        }
    }

    /// <summary>
    /// Change the Music Volume of game based in a slider
    /// </summary>
    /// <param name="theSlider">slider volume</param>
    public void ChangeMusicVolume()
    {
        if(m_manager != null)
        {
            m_manager.SetVolume(CatCity.AudioType.Music, MusicSlider.value);
        }
        else
        {
            SetGameManager();
        }
    }

    /// <summary>
    /// Change the Sound Effect Volume of game based in a slider
    /// </summary>
    /// <param name="theSlider">slider volume</param>
    public void ChangeSoundEffectVolume()
    {
        if(m_manager != null)
        {
            m_manager.SetVolume(CatCity.AudioType.SoundEffect, SoundEffecSlider.value);
        }
        else
        {
            SetGameManager();
        }
    }

    /// <summary>
    /// Turn ON/OFF all volumes
    /// </summary>
    /// <param name="toggle">button enabled</param>
    public void ChangeAudioEnabled()
    {
        if(m_manager != null)
        {
            m_manager.SetVolume(audioToggle.isOn);
        }
        else
        {
            SetGameManager();
        }
    }
    #endregion
}