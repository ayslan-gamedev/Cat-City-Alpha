namespace CatCity
{
    using System.Linq;

    public class InventoryActions
    {
        public void AddItem(Inventory inventory, Item newItem)
        {
            byte itemFound = 0;

            foreach(Item item in inventory.InventoryItens)
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
                inventory.InventoryItens.Add(newItem);
            }
        }

        public void RemoveItem(Inventory inventory, Item itemRemove)
        {
            var item = inventory.InventoryItens.FirstOrDefault(x => x.nameOfItem == itemRemove.nameOfItem);
            if(item != null)
            {
                item.quant -= itemRemove.quant;
                if(item.quant <= 0)
                {
                    inventory.InventoryItens.Remove(item);
                }
            }
        }

        public bool VerifyItem(Inventory inventory, Item theitem)
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