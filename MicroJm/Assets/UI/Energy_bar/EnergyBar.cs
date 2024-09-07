using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Energy energy;
    private Image barImage;
    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        energy = new Energy();

    }
    private void Update()
    {
        energy.Update();
        barImage.fillAmount = energy.GetEnergyNormalized();
    }

}

public class Energy
{
    public const int ENERGY_MAX = 100;
    private float energyAmount;
    private float energyConsumeAmount;

    public Energy()
    {
        energyAmount = 100;
        energyConsumeAmount = 30f;
    }

    public void Update()
    {
        energyAmount -= energyConsumeAmount * Time.deltaTime;
    }

    public void TryRegenEnergy(int amount)
    {
        energyAmount += amount;
    }

    public float GetEnergyNormalized()
    {
        return energyAmount / ENERGY_MAX;
    }
    }