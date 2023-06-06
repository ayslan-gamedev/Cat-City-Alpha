using UnityEngine;

[AddComponentMenu("Cat City/Dynamics/RelativeSize")]
public class RelativeSize : MonoBehaviour
{
    public Transform reduze;
    public float sizeFator, minSize, maxSize;

    /// <summary>
    /// Change the player scale based on distance of a pespective point
    /// </summary>
    void Resize()
    {
        transform.localScale = sizeFator * (transform.position - reduze.position) * -1;
        float newSize = Mathf.Clamp(transform.localScale.y, minSize, maxSize);

        transform.localScale = Vector2.one * newSize;
    }

    void Update()
    {
        Resize();
    }
}