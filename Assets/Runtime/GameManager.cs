using UnityEngine;
using CatCity;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// current scene
    /// </summary>
    public string CurrentScene { private set; get; }
    
    /// <summary>
    /// Load a scene with the load scene 
    /// </summary>
    /// <param name="scene">scene to load</param>
    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(EditorVariables.LoadScene.ToString());
        CurrentScene = scene;
    }

    // Called before the scene starts 
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //InitializeInventory();

        saveManager = new SaveManager();
    
    }

    #region Inventory
    public Inventory playerInventory;
    public PlayerInventory lastInventorySaved;

    /// <summary>
    /// Get the current player inventory used in player object
    /// </summary>
    void InitializeInventory()
    {
        playerInventory = GameObject.Find(EditorVariables.PLAYER_OBJECT.ToString()).GetComponent<Inventory>();
        playerInventory.SetInventory(lastInventorySaved);
    }

    #endregion
    public Save objectSave;

    private SaveManager saveManager;

    public void LoadNewScene()
    {
        saveManager.SaveObject = objectSave;
        saveManager.Save(transform, playerInventory.CurrentPlayerInventory);
    }

    public GlobalVariables currentVariables;

    #region Language
    public Languages languageList;

    public Language currentLanguage;

    private void SetLanagueTest()
    {
        currentLanguage = languageList.languages.ToArray()[1];
    }

    public void SeletLanguage(int LanguageIndex)
    {
        currentLanguage = languageList.languages.ToArray()[LanguageIndex];
        Debug.Log(LanguageIndex);
    }
    #endregion

    private void StartGame()
    {

    }
}