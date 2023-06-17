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
        EditorValues editor = new();

        spriteRender = GetComponent<SpriteRenderer>();
        playerObject = GameObject.Find(editor.PLAYER_OBJECT);
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