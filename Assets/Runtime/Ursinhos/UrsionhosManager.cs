using UnityEngine;

public class UrsionhosManager : MonoBehaviour
{
    public void AddUrsinho(int ursionho)
    {
        try
        {
            FindAnyObjectByType<UrsinhosHUD>().CollectImage(ursionho);
        }
        catch
        {
            Debug.LogWarning("ursinho hud not found!");
        }
    }
}