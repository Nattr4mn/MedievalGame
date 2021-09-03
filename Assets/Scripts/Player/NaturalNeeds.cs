using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NaturalNeeds : MonoBehaviour
{
    public float Energy => _energy;
    public float Thirst => _thirst;
    public float Hunger => _hunger;

    [SerializeField] private UnityEvent<float, float, float> Events;
    [SerializeField] private float _energy;
    [SerializeField] private float _thirst;
    [SerializeField] private float _hunger;
    [SerializeField] private PlayerCharacteristics _characteristics;

    private void Awake()
    {
        Events?.Invoke(_energy, _hunger, _thirst);
        StartCoroutine(ConsumptionOfNaturalNeeds());
    }

    private IEnumerator ConsumptionOfNaturalNeeds()
    {
        var fullDay = TimeController.Instance.FullDay;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _hunger -= (0.05f - ((_characteristics.Stamina.Value * 3) / 1000));
            _thirst -= (0.1f - ((_characteristics.Stamina.Value * 6) / 1000));
            _energy -= (1f / fullDay) + (((1f - _hunger) + (1f - _thirst)) / 100f);
            Events?.Invoke(_energy, _hunger, _thirst);
        }
    }
}
