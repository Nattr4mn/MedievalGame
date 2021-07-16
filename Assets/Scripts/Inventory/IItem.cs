using UnityEngine;

public interface IItem
{
    string Name { get; }
    int ItemCount { get; set; }
    Sprite UIIcon { get; }
}
