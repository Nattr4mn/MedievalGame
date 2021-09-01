using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PlayerCharacteristics : MonoBehaviour
{
    public Characteristic Charisma => _charisma;
    public Characteristic Stamina => _stamina;
    public Characteristic Luck => _luck;


    [SerializeField] private Characteristic _charisma;
    [SerializeField] private Characteristic _stamina;
    [SerializeField] private Characteristic _luck;
}
