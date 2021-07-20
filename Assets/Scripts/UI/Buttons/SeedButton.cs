using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedButton : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;
    private GardensManager _gardensManager;
    private Item _item;

    public void Init(GardensManager gardensManager, Item item)
    {
        _item = item;
        _text.text = item.ItemCount.ToString();
        _image.sprite = item.UIIcon;
        _gardensManager = gardensManager;
    }

    public void Action()
    {
        _gardensManager.CurrentSeed = _item.Name;
        _gardensManager.CurrentCrop = _item.Name.Replace("Seed", "");
        _gardensManager.Planting();
    }
}