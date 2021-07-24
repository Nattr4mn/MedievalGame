using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedButton : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;
    private FarmUI _farmUi;
    private IItem _firstItem;
    private IItem _secondsItem;

    public void Init(FarmUI farmUi, Item item, Player player)
    {
        _firstItem = item;
        _secondsItem = player.Items.GetItem(item.Name.Replace("Seed", ""));
        _text.text = item.Count.ToString();
        _image.sprite = item.UiIcon;
        _farmUi = farmUi;
    }

    public void Action()
    {
        _farmUi.FirstItem = _firstItem;
        _farmUi.SecondsItem = _secondsItem;
        _farmUi.Fill();
    }
}
