using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FarmUI : MonoBehaviour
{
    public IItem FirstItem { get => _firstItem; set { _firstItem = value; } }
    public IItem SecondsItem { get => _secondItem; set { _secondItem = value; } }

    [SerializeField] private SeedSelectionWindow _seedSelectionWindow;
    [SerializeField] private ErrorWindow _errorPanel;
    [SerializeField] private GameObject _statusPanel;
    [SerializeField] private GameObject _buttonsPanel;
    [SerializeField] private Slider _productionSlider;
    [SerializeField] private Slider _waterSlider;
    [SerializeField] private List<FarmObject> _farmObjectList;
    [SerializeField] private PlayerItems _playerItems;
    [SerializeField] private AwardWindow _awardWindowTemplate;
    [SerializeField] private Sprite _expSprite;
    private FarmObject _farmObject;
    private IItem _firstItem;   //seed or animal
    private IItem _secondItem;      //harvest or meat
    private bool _sliderUpdate = false;

    public void Fill()
    {
        Item item = (Item)_firstItem;
        UIManager.Instance.ActionButton.gameObject.SetActive(true);
        if (_playerItems.Bucket.Count > 0 && item.Count > 10)
        {
            UIManager.Instance.ActionEvent -= SelectionWindow;
            _seedSelectionWindow.gameObject.SetActive(false);
            _farmObject.Fill(_firstItem, _secondItem);
        }
        else
        {
            _seedSelectionWindow.gameObject.SetActive(false);
            _errorPanel.gameObject.SetActive(true);
            if (_playerItems.Bucket.Count <= 0)
                _errorPanel.Init("Недостаточно воды!");
            if (item.Count < 10)
                _errorPanel.Init("Недостаточно семян!"); 
        }
    }

    public void PourWater()
    {
        _farmObject.PourWater();
    }

    public void DefiningAction()
    {
        _farmObject = _farmObjectList.FirstOrDefault(item => item.Player != null);

        if (_farmObject != null)
        {
            StartCoroutine(SliderUpdate());
            switch (_farmObject.Occupied)
            {
                case false:
                    UIManager.Instance.ActionEvent += SelectionWindow;
                    break;
                case true:
                    if (_farmObject.CanCollect)
                    {
                        UIManager.Instance.ActionEvent += Collecting;
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
            UIManager.Instance.ActionEvent -= Collecting;
            UIManager.Instance.ActionEvent -= SelectionWindow;
        }
    }

    private void SelectionWindow()
    {
        UIManager.Instance.ActionButton.gameObject.SetActive(false);
        _seedSelectionWindow.gameObject.SetActive(true);
    }

    private void Collecting()
    {
        UIManager.Instance.ActionEvent -= Collecting;
        _farmObject.Collecting();
        StartCoroutine(Awards());
    } 
    
    private IEnumerator Awards()
    {
        Instantiate(_awardWindowTemplate, transform).Init(_farmObject.Harvest.ToString(), _farmObject.СurrentObject.UiIcon);
        yield return new WaitForSeconds(1.5f);
        Instantiate(_awardWindowTemplate, transform).Init(_farmObject.Experience.ToString(), _expSprite);
    }

    private IEnumerator SliderUpdate()
    {
        _sliderUpdate = true;
        while (_sliderUpdate)
        {
            _statusPanel.transform.position = Camera.main.WorldToScreenPoint(_farmObject.transform.position);
            _productionSlider.value = _farmObject.Production;
            _waterSlider.value = _farmObject.Water;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
