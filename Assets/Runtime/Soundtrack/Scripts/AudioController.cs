using CatCity;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public CatCity.AudioType typeAudio;
 
    /// <summary>
    /// Audio to play
    /// </summary>
    public AudioClip SoundFX { private get; set; }

    [SerializeField] private GameObject GameManagerPreFab;

    private void Awake()
    {
        SetLocalVolume();
    }

    /// <summary>
    /// Make the script take the current volume in Game Manager
    /// </summary>
    public void SetLocalVolume()
    {
        AudioSource Audio = GetComponent<AudioSource>();

        GameManager manager;

        try
        {
            manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        }
        catch
        {
            if(GameManagerPreFab != null)
            {
                Debug.LogWarning("GAME MANAFER NOT FOUND!\n A new manager has ben created to debugging mode");

                Instantiate(GameManagerPreFab);
                SetLocalVolume();
                return;
            }

            Debug.LogWarning("GAME MANAGER NOT FOUND!"); return;
        }
        
        switch(typeAudio)
        {
            case CatCity.AudioType.Music:
                Audio.volume = manager.GameAudioSettings.MusicVolume + manager.GameAudioSettings.MainVolume - 1;
                break;
         
            case CatCity.AudioType.SoundEffect:
                Audio.volume = manager.GameAudioSettings.SoundEffectVolume + manager.GameAudioSettings.MainVolume - 1;
                break;
        }
    }
}