using UnityEngine;
using CatCity;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Data/InventoryData")]
public class Inventory : ScriptableObject
{
    public List<Item> InventoryItens;
}