using UnityEngine;
using CatCity;

public class GameManager : MonoBehaviour
{
    public Languages languageList;

    public Language currentLanguage;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SeletLanguage(int LanguageIndex)
    {
        currentLanguage = languageList.languages.ToArray()[LanguageIndex];
        Debug.Log(LanguageIndex);
    }

    public GlobalVariables currentVariables;
}