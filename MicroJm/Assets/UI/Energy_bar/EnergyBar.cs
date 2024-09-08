using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Slider slider;
    public float energyAmt;
    public int StartEnergy;
    public int energyConsumeAmt;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        energyAmt = StartEnergy;
    }
    private void Update()
    {
        
        
        slider.value = energyAmt;
        if (energyAmt < 0)
        {
            energyAmt = 0;
        }
        else
        {
            energyAmt = energyAmt - energyConsumeAmt * Time.deltaTime;
        }
       
    }
    public void Regen(int energy)
    {
        int prevval = energyConsumeAmt;
        energyConsumeAmt = 0;
        energyAmt += energy;
        energyConsumeAmt = prevval;
    }

}
