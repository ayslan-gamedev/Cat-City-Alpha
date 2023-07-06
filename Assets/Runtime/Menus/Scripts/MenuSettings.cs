using CatCity;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    #region Initialize
    private void Awake()
    {
        SetGameManager();
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
    /// <summary>
    /// Change the Dafault Volume of game based in a slider
    /// </summary>
    /// <param name="theSlider">slider volume</param>
    public void ChangeMainVolume(Slider theSlider)
    {
        m_manager.SetVolume(CatCity.AudioType.Default, theSlider.value);
    }

    /// <summary>
    /// Change the Music Volume of game based in a slider
    /// </summary>
    /// <param name="theSlider">slider volume</param>
    public void ChangeMuscVolume(Slider theSlider)
    {
        m_manager.SetVolume(CatCity.AudioType.Music, theSlider.value);
    }

    /// <summary>
    /// Change the Sound Effect Volume of game based in a slider
    /// </summary>
    /// <param name="theSlider">slider volume</param>
    public void ChangeSoundEffectVolume(Slider theSlider)
    {
        m_manager.SetVolume(CatCity.AudioType.SoundEffect, theSlider.value);
    }

    /// <summary>
    /// Turn ON/OFF all volumes
    /// </summary>
    /// <param name="toggle">button enabled</param>
    public void ChangeAudioEnabled(Toggle toggle)
    {
        m_manager.SetVolume(toggle.isOn);
    }
    #endregion
}