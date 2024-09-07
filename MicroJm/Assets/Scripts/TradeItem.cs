using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class TradeItem : MonoBehaviour
{
    public TextMeshProUGUI Item1Name;
    public TextMeshProUGUI Item2Name;
    public TextMeshProUGUI Item1No;
    public TextMeshProUGUI Item2No;
    public Image imageObj1;
    public Image imageObj2;
    public Sprite image1;
    public Sprite image2;

    public string nameSt1;
    public string nameSt2;
    public int Item2NoInt;
    public int Item1NoInt;
    public TextMeshProUGUI ItemMultiplier;
    public int ItemMultiplierInt;
    public bool Usable1;
    public bool Usable2;

    public ShopManager shopManager;
    

    public void Update()
    {
        Item1Name.text = nameSt1;
        Item2Name.text = nameSt2;
        Item1No.text = Item1NoInt.ToString();
        Item2No.text = Item2NoInt.ToString();
        imageObj1.sprite = image1;
        imageObj2.sprite = image2;
        ItemMultiplier.text = "x"+ItemMultiplierInt.ToString();
    }

    public void OnTrade()
    {
        InventoryItem[] items = FindObjectsOfType<InventoryItem>();
        foreach(InventoryItem item in items)
        {
            if (item.nameSt == nameSt2)
            { 
                if(item.stockInt >= Item2NoInt)
                {
                    item.stockInt -= Item2NoInt;
                    
                }
                break;
            }
        }
        bool itemExists = false;
        foreach (InventoryItem existingItem in items)
        {
            

            // If an item with the same name already exists, update its stock
            if (existingItem.nameSt == nameSt1)
            {
                existingItem.stockInt += Item1NoInt;
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

            itemSet.nameSt = nameSt1;
            itemSet.stockInt = Item1NoInt; // Start with the quantity bought
            itemSet.imageObj = imageObj1;
            itemSet.Usable = Usable1;
            // Instantiate and set the new item properties
            GameObject newItem = Instantiate(item, canvas);
            itemSet = newItem.GetComponent<InventoryItem>();


        }
    }


    public void OnItemMultiplier()
    {
        if (ItemMultiplierInt < 10)
        {
            Item2NoInt = Item2NoInt / ItemMultiplierInt;
            Item1NoInt = Item1NoInt / ItemMultiplierInt;
            ItemMultiplierInt++;
            Item2NoInt*= ItemMultiplierInt;
            Item1NoInt *= ItemMultiplierInt;

        }
        else
        {
            ItemMultiplierInt = 1;
            Item2NoInt = Item2NoInt / 10;
            Item1NoInt = Item1NoInt / 10;
        }

    }
}
