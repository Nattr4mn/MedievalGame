using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NaturalNeeds : MonoBehaviour
{
    public Characteristic Energy => _energy;
    public Characteristic Thirst => _thirst;
    public Characteristic Hunger => _hunger;

    [SerializeField] private UnityEvent<float, float, float> Events;
    [SerializeField] private Characteristic _energy;
    [SerializeField] private Characteristic _thirst;
    [SerializeField] private Characteristic _hunger;
    [SerializeField] private PlayerCharacteristics _characteristics;

    private void Awake()
    {
        Events?.Invoke(_energy.Value / _energy.MaxValue, _hunger.Value / _hunger.MaxValue, _thirst.Value / _thirst.MaxValue);
        StartCoroutine(ConsumptionOfNaturalNeeds());
    }

    private IEnumerator ConsumptionOfNaturalNeeds()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            _hunger.Value -= (0.05f - ((_characteristics.Stamina.Value * 3) / 1000));
            _thirst.Value -= (0.1f - ((_characteristics.Stamina.Value * 6) / 1000));
            _energy.Value -= (_hunger.Value - _thirst.Value) / 100;
            Events?.Invoke(_energy.Value / _energy.MaxValue, _hunger.Value / _hunger.MaxValue, _thirst.Value / _thirst.MaxValue);
        }
    }
}
