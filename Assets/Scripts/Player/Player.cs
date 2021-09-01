using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacteristics))]
[RequireComponent(typeof(Resources))]
public class Player : MonoBehaviour
{
    public PlayerInput Input => _playerInput;
    public PlayerCharacteristics Characteristics => _playerCharacteristics;
    public PlayerItems Items => _items;
    public NaturalNeeds NaturalNeeds => _naturalNeeds;
    public PlayerLevel Level => _playerLevel;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerCharacteristics _playerCharacteristics;
    [SerializeField] private PlayerItems _items;
    [SerializeField] private NaturalNeeds _naturalNeeds;
    [SerializeField] private PlayerLevel _playerLevel;
}
