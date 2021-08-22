using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedsButton : MonoBehaviour, ISelectionButton
{
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;
    private FarmUI _farmUi;
    private Crop _crop;

    public void Init(FarmUI farmUi, IItem item)
    {
        _crop = (Crop)item;
        _text.text = _crop.Seed.Count.ToString();
        _image.sprite = _crop.Seed.UiIcon;
        _farmUi = farmUi;
    }

    public void Action()
    {
        print(_crop.Name);
        print(_farmUi);
        _farmUi.ExtractedResource = _crop;
        _farmUi.Fill();
    }
}
