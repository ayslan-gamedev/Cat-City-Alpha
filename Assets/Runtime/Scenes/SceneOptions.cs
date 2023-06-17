using UnityEngine;
using UnityEngine.SceneManagement;
using CatCity;

[AddComponentMenu("Cat City/Scene Manager")]
public class SceneOptions : MonoBehaviour
{
    public void LoadSceneButton(string sceneName)
    {
        EditorValues globalVariables = new();

        if(GameObject.Find(globalVariables.GAME_MANAGER) != null)
        {
            GameObject.Find(globalVariables.GAME_MANAGER).GetComponent<GameManager>().LoadNewScene();
        }
        
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}