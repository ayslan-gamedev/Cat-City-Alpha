using UnityEngine;
using UnityEngine.UI;

public class UrsinhosHUD : MonoBehaviour
{
    public Image[] ursionhosImages;
    public UrsinhosInventory inventoryFile;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        for(int i = 0; i < inventoryFile.ursinhos.Length; i++)
        {
            if(inventoryFile.ursinhos[i] == 1)
            {
                CollectImage(i);
            }
        }
    }

    public void CollectImage(int ursinho)
    {
        ursionhosImages[ursinho].color = new Color(255, 255, 255, 255);
        inventoryFile.ursinhos[ursinho] = 1;
    }
}