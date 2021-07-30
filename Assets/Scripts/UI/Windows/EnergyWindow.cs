using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyWindow : MonoBehaviour
{
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Slider _hungryEnergy;
    [SerializeField] private Slider _thirstEnergy;

    public void ValueSet(float energy, float hungry, float thirst)
    {
        _energySlider.value = energy;
        _hungryEnergy.value = hungry;
        _thirstEnergy.value = thirst;
    }
}
