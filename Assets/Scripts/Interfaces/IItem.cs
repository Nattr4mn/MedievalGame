using UnityEngine;

public interface IItem
{
    public string Name { get; }
    public float Count { get; set; }
    public float Price { get; }
    public ItemType Type { get; }
    public Sprite UiIcon { get; }
}
