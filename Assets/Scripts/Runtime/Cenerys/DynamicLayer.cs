using CatCity;
using UnityEngine;

[AddComponentMenu("Cat City/Dynamics/Layers")]
public class DynamicLayer : MonoBehaviour {

    public float minPosY;
    public int[] layerOrder;

    private SpriteRenderer spriteRender;
    private GameObject playerObject;

    GlobalValues globalVariables;

    // called in the first freame object
    void Start()
    {
        globalVariables = new GlobalValues();

        spriteRender = GetComponent<SpriteRenderer>();
        playerObject = GameObject.Find(globalVariables.PLAYER_NAME);
    }

    //called by game time
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