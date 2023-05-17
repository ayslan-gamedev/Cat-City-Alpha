using UnityEngine;
using UnityEngine.Events;

public class types : MonoBehaviour
{
    public UnityEvent @event;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Test(Component component)
    {
        Debug.Log(component.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
