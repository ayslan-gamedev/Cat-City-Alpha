using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatCity.Inventory
{
    [System.Serializable]
    public class InventoryCell : MonoBehaviour
    {
        public Item itemInCell;

        public Image imageText;
        public TextMeshProUGUI objectNameText;
        public TextMeshProUGUI amountText;

        /// <summary>
        /// Set the image of object
        /// </summary>
        /// <param name="sprite">sprite</param>
        public void SetSprite(Sprite sprite)
        {
            imageText.sprite = sprite;

            imageText.rectTransform.sizeDelta = sprite.textureRect.size;

            if(imageText.rectTransform.sizeDelta.y < 200)
            {
                float diference = 200 - imageText.rectTransform.sizeDelta.y;

                imageText.rectTransform.sizeDelta = new(imageText.rectTransform.sizeDelta.x + diference, imageText.rectTransform.sizeDelta.y + diference);
            }
        }

        /// <summary>
        /// Set the new Item
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(Item item)
        {
            Item newItem = new()
            {
                name = item.name,
                amount = item.amount,
                sprite = item.sprite
            };

            SetSprite(newItem.sprite);
            objectNameText.text = newItem.name;
            amountText.text = newItem.amount.ToString();

            itemInCell = newItem;
        }

        /// <summary>
        /// Set the new Item
        /// </summary>
        public void SetItem()
        {
            Item newItem = new()
            {
                name = itemInCell.name,
                amount = itemInCell.amount,
                sprite = itemInCell.sprite
            };

            SetItem(newItem);
        }

        /// <summary>
        /// Set the new item
        /// </summary>
        /// <param name="_name">name of item</param>
        /// <param name="_amount">amount of item</param>
        /// <param name="_sprite">sprite of item</param>
        public void SetItem(string _name, double _amount, Sprite _sprite)
        {
            Item newItem = new()
            {
                name = _name,
                amount = _amount,
                sprite = _sprite
            };

            SetItem(newItem);
        }

        /// <summary>
        /// Add more amount to item
        /// </summary>
        /// <param name="amountToAdd">amount to add to item</param>
        public void AddMoreItem(double amountToAdd)
        {
            Item newItem = new()
            {
                name = itemInCell.name,
                amount = itemInCell.amount + amountToAdd,
                sprite = itemInCell.sprite
            };

            SetItem(newItem);
        }
    }
}