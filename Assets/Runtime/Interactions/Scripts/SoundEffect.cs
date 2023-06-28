using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
