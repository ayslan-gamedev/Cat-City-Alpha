using UnityEngine;
using CatCity;

[AddComponentMenu("Cat City/Dynamics/Layers")]
public class DynamicLayer : MonoBehaviour 
{
    public float minPosY;
    public int[] layerOrder;

    private SpriteRenderer spriteRender;
    private GameObject playerObject;

    public const string PLAYER_OBJECT = "Player";

    void Start()
    {

        spriteRender = GetComponent<SpriteRenderer>();
        playerObject = GameObject.Find(PLAYER_OBJECT);
    }

    void Update()
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
}