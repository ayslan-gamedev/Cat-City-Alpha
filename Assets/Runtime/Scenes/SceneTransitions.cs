using CatCity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private GameManager manager;

    private void Start()
    {
        manager = GameObject.Find(EditorVariables.GAME_MANAGER.ToString()).GetComponent<GameManager>();
    }

    /// <summary>
    /// Load a scene with the load scene 
    /// </summary>
    /// <param name="scene">scene to load</param>
    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(EditorVariables.LoadScene.ToString());
        //CurrentScene = scene;
    }
}