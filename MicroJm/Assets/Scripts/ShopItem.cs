using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;


public class ShopItem : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI name;
    public TextMeshProUGUI stock;
    public TextMeshProUGUI price;
    public TextMeshProUGUI quantity;
    public Image imageObj;
    public Sprite image;

    public string nameSt;
    public int stockInt;
    public int priceint;
    public int quantityInt;
    public ShopManager shopManager;
    public bool Usable = false;

    public void Update()
    {
        name.text = nameSt;
        quantity.text = quantityInt.ToString();
        price.text = priceint + " Coins";
        stock.text = "Stock : "+ stockInt.ToString();
        imageObj.sprite = image;
    }
    
    public void OnBuy()
    {
        if (stockInt >= quantityInt && shopManager.Coins >= priceint)
        {
            bool itemExists = false;
            foreach (Transform inventoryItem in shopManager.InventoryCanvas)
            {
                InventoryItem existingItem = inventoryItem.GetComponent<InventoryItem>();

                // If an item with the same name already exists, update its stock
                if (existingItem.nameSt == nameSt)
                {
                    existingItem.stockInt += quantityInt;
                    itemExists = true;
                    break; // Stop searching since we've found the item
                }
            }

            // If the item doesn't exist, instantiate a new one
            if (!itemExists)
            {
                GameObject item = shopManager.InventoryItem;
                InventoryItem itemSet = item.GetComponent<InventoryItem>();
                Transform canvas = shopManager.InventoryCanvas;

                itemSet.nameSt = nameSt;
                itemSet.stockInt = stockInt + quantityInt; // Start with the quantity bought
                itemSet.imageObj = imageObj;
                itemSet.Usable = Usable;
                // Instantiate and set the new item properties
                GameObject newItem = Instantiate(item, canvas);
                itemSet = newItem.GetComponent<InventoryItem>();

                
            }

            // Update shop stock and reduce player's coins
            stockInt -= quantityInt;
            shopManager.Coins -= priceint;
        }
        
        else if(stockInt < quantityInt)
        {

        }
        else if (shopManager.Coins < priceint)
        {

        }
    }


    public void OnQuantity()
    {
        if(quantityInt < 10)
        {
            quantityInt++;
        }
        else
        {
            quantityInt = 1;
        }
       
    }
}
