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
                Debug.LogWarning("Game Manager not found in current scene!\nA new temporary Game Manager has been created for debug mode");

                Instantiate(GameManagerPreFab);
                SetLocalVolume();
                return;
            }

            Debug.LogWarning("Game Manager not found in current scene!"); return;
        }
        
        switch(typeAudio)
        {
            case CatCity.AudioType.Music:
                Audio.volume = manager.RuntimeAudioSettings.MusicVolume + manager.RuntimeAudioSettings.MainVolume - 1;
                break;
         
            case CatCity.AudioType.SoundEffect:
                Audio.volume = manager.RuntimeAudioSettings.SoundEffectVolume + manager.RuntimeAudioSettings.MainVolume - 1;
                break;
        }

        Audio.mute = !manager.RuntimeAudioSettings.EnableSound;
    }
}