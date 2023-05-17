using System.Linq;
using UnityEngine;

namespace CatCity
{
    [AddComponentMenu("Cat City/Inventory")]
    public class Inventory : MonoBehaviour
    {
        /// <summary>
        /// return the current player invetory running
        /// </summary>
        public PlayerInventory currentPlayerInventory { get; private set; }
        
        /// <summary>
        /// Set a new inventory player
        /// </summary>
        public void SetInventory()
        {
            currentPlayerInventory = new PlayerInventory();
        }

        /// <summary>
        /// Set a saved inventory player
        /// </summary>
        public void SetInventory(PlayerInventory _inventory)
        {
            if(_inventory != null)
            {
                currentPlayerInventory = _inventory;
            }
            else
            {
                SetInventory();
            }
        }

        /// <summary>
        /// Add a item to current player inventory
        /// </summary>
        public void AddItem(Item newItem)
        {
            byte itemFound = 0;

            foreach(Item item in currentPlayerInventory.InventoryItens)
            {
                if(item.name == newItem.name)
                {
                    item.quant += newItem.quant;
                    itemFound = 1;
                    break;
                }
            }

            if(itemFound != 1)
            {
                currentPlayerInventory.InventoryItens.Add(newItem);
            }
        }

        /// <summary>
        /// Creat a item to Add to current inventory
        /// </summary>
        public void AddItem(string _name)
        {
            Item item = new Item();
            item.name = _name;
            item.quant = 1;

            AddItem(item);
        }

        /// <summary>
        /// Creat a item to Add to current inventory
        /// </summary>
        public void AddItem(string _name, int _quant)
        {
            Item item = new Item();
            item.name = _name;
            item.quant = _quant;

            AddItem(item);
        }

        /// <summary>
        /// Remove a item to current player inventory
        /// </summary>
        public void RemoveItem(Item itemRemove)
        {
            var item = currentPlayerInventory.InventoryItens.FirstOrDefault(x => x.name == itemRemove.name);
            if(item != null)
            {
                item.quant -= itemRemove.quant;
                if(item.quant <= 0)
                {
                    currentPlayerInventory.InventoryItens.Remove(item);
                }
            }
        }

        /// <summary>
        /// Creat a item to Add to current inventory
        /// </summary>
        public void RemoveItem(string _name)
        {
            Item item = new Item();
            item.name = _name;
            item.quant = 2;

            RemoveItem(item);
        }

        /// <summary>
        /// Creat a item to Add to current inventory
        /// </summary>
        public void RemoveItem(string _name, int _quant)
        {
            Item item = new Item();
            item.name = _name;
            item.quant = _quant;

            RemoveItem(item);
        }

        /// <summary>
        /// Verify if a item exists in current player inventory
        /// </summary>
        public bool VerifyItem(PlayerInventory inventory, Item theitem)
        {
            foreach(Item item in inventory.InventoryItens)
            {
                if(theitem.name == item.name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}