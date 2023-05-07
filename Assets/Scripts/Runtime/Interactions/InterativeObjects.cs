using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class InterativeObjects : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    public UnityEvent @event;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(PLAYER_TAG))
        {
            @event.Invoke();
        }
    }
}