using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Animal")]
public class Animal : ScriptableObject, IItem
{
    public string Name => _name;
    public float Count { get => _count; set { _count = value; } }
    public float Price => _price;
    public ItemType Type => _type;
    public Sprite UiIcon => _uiIcon;
    public GameObject Object => _object;
    public Crop RequiredFood => _requiredFood;
    public Item Meat => _meat;

    [SerializeField] private string         _name;
    [SerializeField] private float          _count;
    [SerializeField] private float          _price;
    [SerializeField] private Crop           _requiredFood;
    [SerializeField] private Item           _meat;
    [SerializeField] private ItemType       _type;
    [SerializeField] private Sprite         _uiIcon;
    [SerializeField] private GameObject     _object;    
}
