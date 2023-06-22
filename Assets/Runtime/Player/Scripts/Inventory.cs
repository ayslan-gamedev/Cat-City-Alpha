using System.Collections.Generic;
using UnityEngine;

namespace CatCity
{
    [CreateAssetMenu(fileName = "Player Inventory", menuName = "PLayer/Inventory")]
    public class Inventory : ScriptableObject
    {
        public List<Item> items;
    }

    [System.Serializable]
    public class Item
    {
        public string name;
        public double quant;
        public Sprite sprite;
    }
}