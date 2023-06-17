using CatCity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
    AudioSource audio;

    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {

        if(!GameObject.Find(EditorVariables.GAME_MANAGER.ToString()))
        {
            return;
        }
        
        manager = GameObject.Find(EditorVariables.GAME_MANAGER.ToString()).GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
