using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using CatCity;

[AddComponentMenu("Cat City/Manager Ultilitys")]
public class ManagerUltilitys : MonoBehaviour
{
    [SerializeField] private GameObject LoadSceneControllerPreFab;
    [SerializeField] private GameObject GameManagerPreFab;

    public UnityEvent onStartEvent;

    // Called in the first freame
    private void Start()
    {
        onStartEvent.Invoke();
    }

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

    /// <summary>
    /// Try found the game manager in scene and load a new language, 
    /// not work if game manager dosen't exists
    /// </summary>
    /// <param name="languageIndex">the index of language, based by langauge list seted in game manager/>/></param>
    public void SetNewLanguage(int languageIndex)
    {
        try
        {
            FindAnyObjectByType<GameManager>().SetGameLanguage(languageIndex);
        }
        catch
        {
            if(GameManagerPreFab != null)
            {
                Debug.LogWarning("GAME MANAFER NOT FOUND!\n A new manager has ben created to debugging mode");

                Instantiate(GameManagerPreFab);
                SetNewLanguage(languageIndex);

                return;
            }

            Debug.LogWarning("GAME MANAGER NOT FOUND!");
        }
    }
}