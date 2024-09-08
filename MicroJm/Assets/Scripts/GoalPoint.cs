using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    public EnergyBar EnergyBar;
    private void Start()
    {
        EnergyBar = GameObject.FindGameObjectWithTag("Energy").GetComponent<EnergyBar>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnergyBar.energyConsumeAmt = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnergyBar.energyConsumeAmt = 5;
    }
}
