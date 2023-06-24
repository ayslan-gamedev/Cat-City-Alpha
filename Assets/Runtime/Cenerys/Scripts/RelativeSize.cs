using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Cat City/Dynamics/RelativeSize")]
public class RelativeSize : MonoBehaviour
{
    public Transform reduze;
    public float sizeFator, minSize, maxSize;

    // Change the player scale based on distance of a pespective point
    void Update()
    {
        transform.localScale = sizeFator * (transform.position - reduze.position) * -1;
        float newSize = Mathf.Clamp(transform.localScale.y, minSize, maxSize);

        transform.localScale = Vector2.one * newSize;
    }
}