using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalsButton : MonoBehaviour, ISelectionButton
{
    [SerializeField] private Text _priceText;
    [SerializeField] private Image _requiredFoodImage;
    [SerializeField] private Image _image;
    private AbstractFarmUI _farmUi;
    //private Animal _animal;

    public void Init(AbstractFarmUI farmUi, IFarmProduct item)
    {
        //_animal = (Animal)item;
        //_farmUi = farmUi;
        //_priceText.text = _animal.Price.ToString();
        //_requiredFoodImage.sprite = _animal.RequiredFood.UiIcon;
        //_image.sprite = _animal.UiIcon;
    }

    public void Action()
    {
        //_farmUi.ExtractedResource = _animal;
        //_farmUi.Fill();
    }
}
