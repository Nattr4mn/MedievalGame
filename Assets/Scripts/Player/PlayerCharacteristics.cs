using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : Loader<PlayerCharacteristics>
{
    public float Charisma => charisma;
    public float Endurance => endurance;
    public float Luck => luck;

    private float level = 0;
    private float experience = 0;
    private float charisma = 1;
    private float endurance = 1;
    private float luck = 1;
    private float curThirst = 10;
    private float maxThirst = 10;
    private float curHunger = 10;
    private float maxHunger = 10;
    private float expenseMultiplier = 1;

    private void Start()
    {
        UIManager.Instance.hungerSlider.value = curHunger / maxHunger;
        UIManager.Instance.thirstSlider.value = curThirst / maxThirst;
        StartCoroutine(ConsumptionOfNaturalNeeds());
    }

    public void ReplenishingThirst(float value)
    {
        if (value > maxThirst)
        {
            curThirst = maxThirst;
        }
        else if (value > 0)
        {
            if (curThirst + value > maxThirst)
                curThirst = maxThirst;
            else
                curThirst += value;
        }
    }

    public void ReplenishingHunger(float value)
    {
        if (value > maxHunger)
        {
            curHunger = maxHunger;
        }
        else if (value > 0)
        {
            if (curHunger + value > maxHunger)
                curHunger = maxHunger;
            else
                curHunger += value;
        }
        
    }

    private IEnumerator ConsumptionOfNaturalNeeds()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            curHunger -= 0.05f * expenseMultiplier;
            curThirst -= 0.1f * expenseMultiplier;
            UIManager.Instance.hungerSlider.value = curHunger / maxHunger;
            UIManager.Instance.thirstSlider.value = curThirst / maxThirst;
        }
    }
}
