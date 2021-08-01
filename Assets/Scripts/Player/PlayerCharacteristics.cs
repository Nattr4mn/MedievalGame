using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PlayerCharacteristics : MonoBehaviour
{
    public float Experience => _experience;
    public Characteristic Level => _level;
    public Characteristic Charisma => _charisma;
    public Characteristic Stamina => _stamina;
    public Characteristic Luck => _luck;


    private float _experience = 0f;
    [SerializeField] private Characteristic _level;
    [SerializeField] private Characteristic _charisma;
    [SerializeField] private Characteristic _stamina;
    [SerializeField] private Characteristic _luck;

    public void AddExperience(float experience)
    {
        _experience += experience;
        if(_experience >= 10 + (1 * _level.Value))
        {
            if(_level.Value != _level.MaxValue)
            {
                _experience -= (10 + (1 * _level.Value));
                _level.Value++;
            }
        }
    }
}
