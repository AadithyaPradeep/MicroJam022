using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI name;
    public TextMeshProUGUI stock;
    public GameObject Use;
    public Image imageObj;
    public Sprite image;

    public string nameSt;
    public int stockInt;
    
    public ShopManager shopManager;
    public bool Usable;
    public EnergyBar energyBar;
    public int energy;
    /* Make Inventory Class and Add Here
     * public Inventory inventory;
    public GameObject InventoryObj;*/

    
    public void Start()
    {
        energyBar = GameObject.FindGameObjectWithTag("Energy").GetComponent<EnergyBar>();
        Use.SetActive(false);
        if(Usable)
        {
            Use.SetActive(true);
        }
    }
    public void Update()
    {
        if(stockInt <= 0)
        {
            Destroy(gameObject);
        }
        name.text = nameSt;
        
        stock.text = "Stock : "+ stockInt.ToString();
        imageObj.sprite = image;
        
    }
    
    public void OnUse()
    {
        stockInt--;
        energyBar.Regen(energy);
    }
    
}
