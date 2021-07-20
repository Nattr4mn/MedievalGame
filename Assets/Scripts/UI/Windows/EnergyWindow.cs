using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyWindow : MonoBehaviour, IWindow
{
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Slider _hungryEnergy;
    [SerializeField] private Slider _thirstEnergy;
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void ValueSet(float energy, float hungry, float thirst)
    {
        _energySlider.value = energy;
        _hungryEnergy.value = hungry;
        _thirstEnergy.value = thirst;
    }
}
