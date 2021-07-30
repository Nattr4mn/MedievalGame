using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLine : MonoBehaviour
{
    [SerializeField] private Text _countField;
    [SerializeField] private Image _iconField;

    public void Render(IItem item)
    {
        _countField.text = item.Count.ToString();
        _iconField.sprite = item.UiIcon;
    }
}
