using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Cat City/Manager Ultilitys")]
public class ManagerUltilitys : MonoBehaviour
{
    [SerializeField] private GameObject LoadSceneControllerPreFab;

    /// <summary>
    /// Try found the Laod scene controller in scene and load a new scene, 
    /// not work if LoadSceneController dosen't exists
    /// </summary>
    /// <param name="scene">scene to load</param>
    public void LoadNewScene(string scene)
    {
        try
        {
            FindAnyObjectByType<LoadSceneController>().LoadNewScene(scene);
        }
        catch
        {
            if(LoadSceneControllerPreFab != null)
            {
                Debug.LogWarning("LOAD SCENE CONTROLLER NOT FOUND!\n A new load scene controle has ben created to debugging mode");

                Instantiate(LoadSceneControllerPreFab);
                LoadNewScene(scene);

                return;
            }

            Debug.LogWarning("LOAD SCENE CONTROLLER NOT FOUND!");
            SceneManager.LoadSceneAsync(scene);
        }
    }
}