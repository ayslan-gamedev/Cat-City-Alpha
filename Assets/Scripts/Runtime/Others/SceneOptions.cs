using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Cat City/Scene Manager")]
public class SceneOptions : MonoBehaviour
{
    public void LoadSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}