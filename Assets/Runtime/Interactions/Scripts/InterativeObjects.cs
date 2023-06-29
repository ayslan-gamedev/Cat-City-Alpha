using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[AddComponentMenu("Cat City/Interative")]
public class InterativeObjects : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    public UnityEvent @event;

    private byte onpened = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(PLAYER_TAG) && onpened == 0)
        {
            @event.Invoke();
            onpened = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(PLAYER_TAG))
        {
            onpened = 0;
        }
    }
}