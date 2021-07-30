using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject, IItem
{
    public string Name => _name;
    public float Count { get => _count; set { _count = value; } }
    public float Price { get => _price; set { _price = value; } }
    public ItemType Type => _type;
    public Sprite UiIcon => _uiicon;

    [SerializeField] private string     _name;
    [SerializeField] private float      _count;
    [SerializeField] private float      _price;
    [SerializeField] private ItemType   _type;
    [SerializeField] private Sprite     _uiicon;

}