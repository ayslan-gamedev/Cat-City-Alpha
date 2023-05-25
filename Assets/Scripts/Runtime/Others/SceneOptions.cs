using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Cat City/Scene Manager")]
public class SceneOptions : MonoBehaviour
{
    private const string GAME_MANAGER = "GameManager";

    public void LoadSceneButton(string sceneName)
    {
        if(GameObject.Find(GAME_MANAGER) != null)
        {
            GameObject.Find(GAME_MANAGER).GetComponent<GameManager>().LoadNewScene();
        }
        
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}