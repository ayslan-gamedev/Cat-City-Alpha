using UnityEngine;
using CatCity;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Data/InventoryData")]
public class PlayerInventory : ScriptableObject
{
    public List<Item> InventoryItens;
}