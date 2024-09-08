using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GetTradeItem : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> items;
    public GameObject TradeItem;
    public RandomItemInstantiate shopRandom;
    public int itemNo;
    public Transform spawnCanvas;
    public int num1, num2;
    public int MinValue;
    public int MaxValue;
    public int Count;


    void Start()
    {
        Count = items.Count;
        itemNo = Random.Range(3, 5);
        for (int i = 0; i < itemNo; i++)
        {
            
            num1 = Random.Range(0, Count - 1);
            num2 = Random.Range(0, Count - 1);
            while (num1 == num2)
            {
                num2 = Random.Range(0, num1);
            }

            
            TradeItem.GetComponent<TradeItem>().nameSt1 = items[num1].GetComponent<ShopItem>().nameSt;
            TradeItem.GetComponent<TradeItem>().nameSt2 = items[num2].GetComponent<ShopItem>().nameSt;
            TradeItem.GetComponent<TradeItem>().Item1NoInt = items[num1].GetComponent<ShopItem>().value;
            TradeItem.GetComponent<TradeItem>().Item2NoInt = items[num2].GetComponent<ShopItem>().value;
            if (GCD(TradeItem.GetComponent<TradeItem>().Item1NoInt, TradeItem.GetComponent<TradeItem>().Item2NoInt) != 0)
            {
                TradeItem.GetComponent<TradeItem>().Item1NoInt /= GCD(TradeItem.GetComponent<TradeItem>().Item1NoInt, TradeItem.GetComponent<TradeItem>().Item2NoInt);
                TradeItem.GetComponent<TradeItem>().Item2NoInt /= GCD(TradeItem.GetComponent<TradeItem>().Item1NoInt, TradeItem.GetComponent<TradeItem>().Item2NoInt);
            }
            MinValue = Mathf.Clamp((int)(TradeItem.GetComponent<TradeItem>().Item1NoInt / TradeItem.GetComponent<TradeItem>().Item2NoInt * Random.Range(-1f, 0f)), -2, 0);
            MaxValue = Mathf.Clamp((int)(TradeItem.GetComponent<TradeItem>().Item1NoInt / TradeItem.GetComponent<TradeItem>().Item2NoInt * Random.Range(0f, 1f)), 0, 2);


            TradeItem.GetComponent<TradeItem>().Item1NoInt = Mathf.Max(TradeItem.GetComponent<TradeItem>().Item1NoInt + (Random.Range(0, 2) == 2 ? Random.Range(MinValue, MaxValue) : 0),1);
            TradeItem.GetComponent<TradeItem>().Item2NoInt = Mathf.Max(TradeItem.GetComponent<TradeItem>().Item2NoInt + (Random.Range(0, 2) == 2 ? Random.Range(MinValue, MaxValue) : 0),1);
            Instantiate(TradeItem, spawnCanvas);
            items.RemoveAll(x => x.name == items[num1].name);
            items.RemoveAll(x => x.name == items[num2].name);
            
            Count = items.Count;
        }
    }
    public static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
    
}

