using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LoadSceneButton(string sceneName)
    {
        Debug.Log("Try load");
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}