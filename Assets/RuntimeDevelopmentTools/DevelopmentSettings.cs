using UnityEngine;
using CatCity;
using CatCity.Editor;

[ExecuteInEditMode]
[ExecuteAlways]
[RequireComponent(typeof(GameManager))]
public class DevelopmentSettings : MonoBehaviour
{
    public GameSettings currentGameSettings;
    private GameManager manager;

    void Start()
    {
        manager = GetComponent<GameManager>();

        #if UNITY_EDITOR
        if(currentGameSettings == null)
        {
            Debug.LogError("DEVELOPMENT FILE NOT FOUND");
            Destroy(manager.gameObject);
        }
        #endif
        
       
    }

    public void CallCheat(string cheat)
    {

    }
}