using System.Linq;

namespace CatCity
{
    public class Inventory
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
                if(item.nameOfItem == newItem.nameOfItem)
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
        /// Remove a item to current player inventory
        /// </summary>
        public void RemoveItem(Item itemRemove)
        {
            var item = currentPlayerInventory.InventoryItens.FirstOrDefault(x => x.nameOfItem == itemRemove.nameOfItem);
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
        /// Verify if a item exists in current player inventory
        /// </summary>
        public bool VerifyItem(PlayerInventory inventory, Item theitem)
        {
            foreach(Item item in inventory.InventoryItens)
            {
                if(theitem.nameOfItem == item.nameOfItem)
                {
                    return true;
                }
            }
            return false;
        }
    }
}