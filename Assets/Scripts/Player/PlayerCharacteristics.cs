using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacteristics : MonoBehaviour
{
    public float Experience => experience;
    public Characteristic Level => _level;
    public Characteristic Charisma => _charisma;
    public Characteristic Stamina => _stamina;
    public Characteristic Luck => _luck;
    public Characteristic Energy => _energy;
    public Characteristic Thirst => _thirst;
    public Characteristic Hunger => _hunger;


    private float experience = 0f;
    [SerializeField] private Characteristic _level;
    [SerializeField] private Characteristic _charisma;
    [SerializeField] private Characteristic _stamina;
    [SerializeField] private Characteristic _luck;
    [SerializeField] private Characteristic _energy;
    [SerializeField] private Characteristic _thirst;
    [SerializeField] private Characteristic _hunger;
    [SerializeField] private UnityEvent<float, float, float> EnergyEvents;

    private void Awake()
    {
        EnergyEvents?.Invoke(_energy.Value / _energy.MaxValue, _hunger.Value / _hunger.MaxValue, _thirst.Value / _thirst.MaxValue);
        StartCoroutine(ConsumptionOfNaturalNeeds());
    }

    private IEnumerator ConsumptionOfNaturalNeeds()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            _hunger.Value -= (0.05f - ((_stamina.Value * 3) / 1000));
            _thirst.Value -= (0.1f - ((_stamina.Value * 6) / 1000));
            _energy.Value -= (_hunger.Value - _thirst.Value) / 100;
            EnergyEvents?.Invoke(_energy.Value / _energy.MaxValue, _hunger.Value / _hunger.MaxValue, _thirst.Value / _thirst.MaxValue);
        }
    }
}
