using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    private const string LOAD_SCENE = "LoadScene";

    // Called wen the scene starts
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        loadingCanvas.SetActive(false);
    }

    // the load bar
    [SerializeField] private Slider loadingSlider;
    // the customize canvas of loading system
    [SerializeField] private GameObject loadingCanvas;

    /// <summary>
    /// Load the scene to load
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadSceneAsync(string scene)
    {
        loadingCanvas.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        
        while(!asyncLoad.isDone)
        {
            if(loadingSlider != null)
            {
                float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                loadingSlider.value = progress;
            }
            
            yield return null;
        }
        loadingCanvas.SetActive(false);
    }

    /// <summary>
    /// Load the new scene
    /// </summary>
    /// <param name="SceneToLoad">name of scene</param>
    public void LoadNewScene(string SceneToLoad)
    {
        SceneManager.LoadSceneAsync(LOAD_SCENE);
        StartCoroutine(LoadSceneAsync(SceneToLoad));
    }
}