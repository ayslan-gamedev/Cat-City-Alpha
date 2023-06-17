using UnityEngine;
using UnityEngine.SceneManagement;
using CatCity;

[AddComponentMenu("Cat City/Scene Manager")]
public class SceneOptions : MonoBehaviour
{
    public void LoadSceneButton(string sceneName)
    {
        if(GameObject.Find(EditorVariables.GAME_MANAGER.ToString()) != null)
        {
            GameObject.Find(EditorVariables.GAME_MANAGER.ToString()).GetComponent<GameManager>().LoadNewScene();
        }
        
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}