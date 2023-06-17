using UnityEngine;
using CatCity;

public class GameManager : MonoBehaviour
{
    #region Global Consts
    #endregion

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
        EditorValues editor = new();

        playerInventory = GameObject.Find(editor.PLAYER_OBJECT).GetComponent<Inventory>();
        playerInventory.SetInventory(lastInventorySaved);
    }

    #endregion
    public Save objectSave;

    private SaveManager saveManager;

    public void LoadNewScene()
    {
        //saveManager.SaveObject = objectSave;
        //saveManager.Save(transform, playerInventory.CurrentPlayerInventory);
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