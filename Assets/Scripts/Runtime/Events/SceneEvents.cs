using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Cat City/Scene Events")]
public class SceneEvents : MonoBehaviour
{
    private GlobalVariables globalVariables;

    public UnityEvent[] @events;

    public void SetGlobalVariables(GlobalVariables variables)
    {
        globalVariables = variables;
    }
}