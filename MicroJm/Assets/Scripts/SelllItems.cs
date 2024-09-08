using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelllItems : MonoBehaviour
{
    public InventoryItem[] Items;
    public ShopManager ShopManager;

    private void Update()
    {
       
       ShopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();
       Items = ShopManager.InventoryCanvas.GetComponentsInChildren<InventoryItem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var item in Items)
        {
            ShopManager.Coins += (item.price + 5) * item.stockInt;
            Destroy(item.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (var item in Items)
        {
            ShopManager.Coins += (item.price + 5) * item.stockInt;
            Destroy(item.gameObject);
        }
    }
}
