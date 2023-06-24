using System.Collections.Generic;
using UnityEngine;
using CatCity.Inventory;

public class InventoryListManager : MonoBehaviour
{
    // preFab of UI element inventory cell
    [SerializeField] private GameObject InventoryCellPreFab;

    /// <summary>
    /// List with all inventory items
    /// </summary>
    [SerializeField] private List<InventoryCell> InventoryItems;

    /// <summary>
    /// Add a new item to Inventory Array
    /// </summary>
    /// <param name="item">new item to add</param>
    public void AddNewItem(Item item)
    {
        // Verify if the item already exists in inventory to amount itens
        for(int i = 0; i < InventoryItems.ToArray().Length; i++)
        {
            if(InventoryItems[i].itemInCell.name == item.name)
            {
                InventoryItems[i].AddMoreItem(item.amount);
                return;
            }
        }

        // creat the new item
        InventoryItems.Add(Instantiate(InventoryCellPreFab, transform).GetComponent<InventoryCell>());
        InventoryItems[InventoryItems.ToArray().Length - 1].SetItem(item);
    }
}