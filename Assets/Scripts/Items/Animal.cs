using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Animal")]
public class Animal : ScriptableObject, IItem
{
    public string Name => _name;
    public float Price => _price;
    public Sprite UiIcon => _uiIcon;
    public GameObject Object => _object;       
    
    [SerializeField] private string _name;
    [SerializeField] private float _price;
    [SerializeField] private Sprite _uiIcon;
    [SerializeField] private GameObject _object;    
}
