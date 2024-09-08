using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomItemInstantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> items = new List<GameObject>();
    public int itemNo;
    public Transform spawnCanvas;
    
    void Start()
    {
        for(int i = 0; i < itemNo; i++) 
        {
            int num = Random.Range(0, items.Count);
            Instantiate(items[num], spawnCanvas);            
            items.RemoveAll(x => x.name == items[num].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
