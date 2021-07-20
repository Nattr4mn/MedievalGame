using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string Name => _name;
    public int ItemCount { get => _itemCount; set { _itemCount = value; } }
    public Sprite UIIcon => _uiicon;

    [SerializeField] private string _name;
    [SerializeField] private int _itemCount;
    [SerializeField] private Sprite _uiicon;

}
