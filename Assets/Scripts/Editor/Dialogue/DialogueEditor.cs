using UnityEditor;

public class DialogueEditor : EditorWindow
{

    [MenuItem("Window/Unity Dialogue/Dialogue Editor")]
    public static void ShowWindow()
    {
        GetWindow<DialogueEditor>("Dialogue Editor");
    }

    void Update()
    {

    }
}