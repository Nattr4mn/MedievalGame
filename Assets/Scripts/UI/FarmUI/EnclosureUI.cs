using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnclosureUI : FarmUI
{
    public override IItem ExtractedResource { get => _currentAnimal; set => _currentAnimal = (Animal)value; }
    public override List<IItem> ItemsList => _animalsList.Select(animal => (IItem)animal).ToList();

    [SerializeField]    private Slider          _saturateSlider;
    [SerializeField]    private List<Animal>    _animalsList;
                        private Animal          _currentAnimal;


    public override void Fill()
    {
        InputUI.Instance.ActionButton.gameObject.SetActive(true);
        if (Player.Items.Gold.Value >= _currentAnimal.Price && Player.Items.Bucket.Value > 0 && _currentAnimal.RequiredFood.Count > 5f)
        {
            InputUI.Instance.Action -= SelectionWindow;
            Selection.gameObject.SetActive(false);
            �urrentFarmObject.Fill(_currentAnimal);
        }
        else
        {
            Selection.gameObject.SetActive(false);
            Error.gameObject.SetActive(true);
            Error.Init("������������ ��������!");
        }
    }

    public override void SelectionWindow()
    {
        InputUI.Instance.ActionButton.gameObject.SetActive(false);
        Selection.Init(ItemsList);
        Selection.gameObject.SetActive(true);
    }

    public void Saturate()
    {
        if (_currentAnimal.RequiredFood.Count > 0)
        {
            AnimalEnclosure animalEnclosure = (AnimalEnclosure)�urrentFarmObject;
            animalEnclosure.Saturate();
        }
        else
        {
            Error.gameObject.SetActive(true);
            Error.Init("������������ ��������!");
        }
    }
    
    public override IEnumerator SliderUpdate()
    {
        AnimalEnclosure animalEnclosure = (AnimalEnclosure)�urrentFarmObject;
        _sliderUpdate = true;
        while (_sliderUpdate)
        {
            _statusPanel.transform.position = Camera.main.WorldToScreenPoint(�urrentFarmObject.transform.position);
            _productionSlider.value = �urrentFarmObject.Production;
            _saturateSlider.value = animalEnclosure.Food;
            _waterSlider.value = �urrentFarmObject.Water;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
