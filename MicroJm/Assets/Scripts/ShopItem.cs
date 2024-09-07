using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


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
    /* Make Inventory Class and Add Here
     * public Inventory inventory;
    public GameObject InventoryObj;*/

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
        if(stockInt >= quantityInt && shopManager.Coins >= priceint)
        {
            //Uncomment this line to add object to inventory when buying
            //Inventory.Add(InventoryObj);
            stockInt = stockInt - quantityInt;
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
