using CatCity;
using UnityEngine;

[AddComponentMenu("Cat City/Inventory")]
public class InventoryManager : MonoBehaviour
{
    private Inventory playerInventory;

    // TODO - CALL BY GAME MANAGER
    void Awake()
    {
        playerInventory = new Inventory();
        playerInventory.SetInventory();
    }

    /// <summary>
    /// Options of itens to use with inventory
    /// </summary>
    public enum ItemOptions { Add, Remove }

    /// <summary>
    /// A generic manager to controll itens to be used in unity editor
    /// </summary>
    public void ItemManager(ItemOptions option, Item item)
    {
        switch(option)
        {
            case ItemOptions.Add:
                playerInventory.AddItem(item);
                break;

            case ItemOptions.Remove:
                playerInventory.RemoveItem(item);
                break;
        }
    }
}