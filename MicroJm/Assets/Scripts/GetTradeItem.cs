using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTradeItem : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> items;
    public RandomItemInstantiate shopRandom;
    public int itemNo;
    public Transform spawnCanvas;

    void Start()
    {
        itemNo = Random.Range(3, 5);
        for (int i = 0; i < itemNo; i++)
        {
            int num = Random.Range(0, items.Count);
            Instantiate(items[num], spawnCanvas);


            items[num].GetComponent<TradeItem>().Item1NoInt = Mathf.Max(items[num].GetComponent<TradeItem>().Item1NoInt + Random.Range(0, 2) == 2 ? Random.Range(items[num].GetComponent<TradeItem>().MinValue, items[num].GetComponent<TradeItem>().MaxValue) : 0, 1);
            items[num].GetComponent<TradeItem>().Item2NoInt = Mathf.Max(items[num].GetComponent<TradeItem>().Item2NoInt + Random.Range(0, 2) == 2 ? Random.Range(items[num].GetComponent<TradeItem>().MinValue, items[num].GetComponent<TradeItem>().MaxValue) : 0, 1);

            items.RemoveAll(x => x.name == items[num].name);
        }
    }
}
