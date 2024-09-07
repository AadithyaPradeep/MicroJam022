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
   

   private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void ToggleShop(bool bl)
    {
        ShopUI.SetActive(bl);
    }
    private void Update()
    {
        CoinsText.text = Coins.ToString();
    }
    
}
