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
        EditorValues editor = new();

        if(!GameObject.Find(editor.GAME_MANAGER))
        {
            return;
        }
        
        manager = GameObject.Find(editor.GAME_MANAGER).GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
