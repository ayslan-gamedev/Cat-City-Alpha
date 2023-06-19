using UnityEngine;
using CatCity;

[AddComponentMenu("Cat City/Dynamics/Layers")]
public class DynamicLayer : MonoBehaviour
{
    public float minPosY;
    public int[] layerOrder;

    private SpriteRenderer spriteRender;
    private GameObject playerObject;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(playerObject != null)
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
            playerObject = GameObject.Find(EditorVariables.PLAYER_OBJECT.ToString());
        }
    }
}