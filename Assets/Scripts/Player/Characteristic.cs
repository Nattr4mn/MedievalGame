using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Characteristic")]
[Serializable]
public class Characteristic : ScriptableObject
{
    public string Name;
    public int Value;
    public int MaxValue;
    public Sprite UiIcon;
}
