using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnclosureUI : MonoBehaviour
{
    [SerializeField] private GameObject _statusPanel;
    [SerializeField] private GameObject _buttonsPanel;
    [SerializeField] private Slider _growthRateSlider;
    [SerializeField] private Slider _foodLvlSlider;
    [SerializeField] private Slider _waterLvlSlider;
    [SerializeField] private AnimalEnclosure _animalEnclosure;
    [SerializeField] private PlayerItems _playerItems;

    private Animal _currentAnimal;
    private Item _food;
    private bool _sliderUpdate = false;

    public void Fill()
    {
        _animalEnclosure.Fill(_currentAnimal, _food);
    }

    public void PourWater()
    {
        _animalEnclosure.PourWater();
        _playerItems.Bucket.Count = 0;
    }

    public void Saturate()
    {

    }

    public void DefiningAction()
    {
        if (_animalEnclosure.Player != null)
        {
            StartCoroutine(SliderUpdate());
            switch (_animalEnclosure.Occupied)
            {
                case false:
                    UIManager.Instance.ActionEvent += SelectionWindow;
                    break;
                case true:
                    if (_animalEnclosure.CanCollect)
                    {
                        UIManager.Instance.ActionEvent += _animalEnclosure.Collecting;
                        _statusPanel.SetActive(false);
                        _buttonsPanel.SetActive(false);
                    }
                    else
                    {
                        _statusPanel.SetActive(true);
                        _buttonsPanel.SetActive(true);
                    }
                    break;
            }
        }
        else
        {
            _sliderUpdate = false;
            _statusPanel.SetActive(false);
            _buttonsPanel.SetActive(false);
            UIManager.Instance.ActionEvent -= _animalEnclosure.Collecting;
            UIManager.Instance.ActionEvent -= SelectionWindow;
        }
    }

    private void SelectionWindow()
    {
        print("Select");
    }

    private IEnumerator SliderUpdate()
    {
        _sliderUpdate = true;
        while (_sliderUpdate)
        {
            _statusPanel.transform.position = Camera.main.WorldToScreenPoint(_animalEnclosure.transform.position);
            _growthRateSlider.value = _animalEnclosure.Production;
            _foodLvlSlider.value = _animalEnclosure.Food;
            _waterLvlSlider.value = _animalEnclosure.Water;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
