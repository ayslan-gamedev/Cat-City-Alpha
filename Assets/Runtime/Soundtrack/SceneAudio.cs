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
        if(!GameObject.Find("GameManager"))
        {
            return;
        }
        
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
