using UnityEngine;
using TMPro;
using CatCity;

[AddComponentMenu("Cat City/UI/Translator")]
public class Translator : MonoBehaviour
{
    /// <summary>
    /// The Text
    /// </summary>
    [TextArea(3, 10)][SerializeField] protected string[] m_Text;

    /// <summary>
    /// Write the text with current Language in GameManager
    /// </summary>
    public void WriteText()
    {
        if(!TryGetComponent<TextMeshProUGUI>(out var textObject))
        {
            return;
        }

        if(GameObject.Find(EditorVariables.GAME_MANAGER.ToString()) != null)
        {
            GameManager manager = GameObject.Find(EditorVariables.GAME_MANAGER.ToString()).GetComponent<GameManager>();
            textObject.text = m_Text[manager.CurrentLanguage.index];
        }
        else
        {
            textObject.text = m_Text[0];
        }
    }

    // Caled in the first freame of object
    private void Start()
    {
        WriteText();
    }
}