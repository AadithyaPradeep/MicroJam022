using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public int Coins = 50;
    public TextMeshProUGUI CoinsText;
    public GameObject ShopUI;
    public GameObject InventoryItem;
    public Transform InventoryCanvas;
    public GameObject InventoryMenu;
    public GameObject TradeUI;

   private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        InventoryMenu.SetActive(false);
    }
    public void ToggleShop(bool bl)
    {
        ShopUI.SetActive(bl);
    }
    public void ToggleTrade(bool bl)
    {
        TradeUI.SetActive(bl);
    }
    private void Update()
    {
        if(ShopUI.activeSelf == false && Input.GetKeyDown(KeyCode.I) && InventoryMenu.activeSelf == false)
        {
            InventoryMenu.SetActive(true);
        }
        else if(ShopUI.activeSelf)
        {
            InventoryMenu.SetActive(false);
        }
        else if(ShopUI.activeSelf == false && Input.GetKeyDown(KeyCode.I) && InventoryMenu.activeSelf == true)
        {
            InventoryMenu.SetActive(false);
        }
        
        CoinsText.text = Coins.ToString();
    }

    
}
