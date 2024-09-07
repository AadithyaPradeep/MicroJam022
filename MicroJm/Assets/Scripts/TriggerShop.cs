using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShop : MonoBehaviour
{
    public bool iscollision;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            iscollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iscollision = false;
            if(ShopManager.instance.ShopUI.active == true)
            {
                ShopManager.instance.ToggleShop(false);
            }
           
        }
    }
    private void Update()
    {
       if(Input.GetKey(KeyCode.E))
        {
            if(iscollision)
            {
                ShopManager.instance.ToggleShop(true);
            }
        }
    }
}
