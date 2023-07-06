using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[AddComponentMenu("Cat City/Interative")]
public class InterativeObjects : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    public InterationType thisInteraction;
    public UnityEvent @event;

    public AudioType thisThypeAudio;
    public AudioSource audio;

    private byte onpened = 0;

    public enum InterationType
    {
        Collect = 0,
        Talk = 1
    }

    // On Player Enter Colision
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(PLAYER_TAG) && onpened == 0)
        {

            @event.Invoke();

            switch(thisInteraction)
            {
                case InterationType.Collect:
                    Destroy(gameObject);
                    break;

                case InterationType.Talk:
                    onpened = 1;
                    break;
            }
        }
    }

    // On Player Exit Colision
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(PLAYER_TAG))
        {
            onpened = 0;
        }
    }
}