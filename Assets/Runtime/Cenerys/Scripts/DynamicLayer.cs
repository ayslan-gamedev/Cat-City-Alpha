using UnityEngine;
using CatCity;
using UnityEngine.AI;

[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
[AddComponentMenu("Cat City/Dynamics/Dynamic Layer")]
public class DynamicLayer : MonoBehaviour
{
    public float minPosY;
    public int[] layerOrder = new int[2];

    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private GameObject playerObject;

    void LateUpdate()
    {
        if(playerObject != null && spriteRender != null)
        {
            if(playerObject.transform.position.y < minPosY)
            {
                spriteRender.sortingOrder = layerOrder[0];
            }
            else
            {
                spriteRender.sortingOrder = layerOrder[1];
            }
        }
        else
        {
            try
            {
                playerObject = FindAnyObjectByType<NavMeshAgent>().gameObject;
            }
            catch
            {
                playerObject = null;
            }
            
            spriteRender = GetComponent<SpriteRenderer>();
        }
    }
}