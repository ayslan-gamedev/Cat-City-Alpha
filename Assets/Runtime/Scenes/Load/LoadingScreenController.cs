using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using CatCity;

public class LoadingScreenController : MonoBehaviour
{
    public string sceneToLoad;

    void Start()
    {
        sceneToLoad = GameObject.Find(EditorVariables.GAME_MANAGER.ToString()).GetComponent<GameManager>().CurrentScene;
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while(!asyncLoad.isDone)
        {
            // TODO: bar load by asyncLoad.progress.

            yield return null;
        }
    }
}