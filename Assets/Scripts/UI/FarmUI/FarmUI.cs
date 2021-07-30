using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class FarmUI : MonoBehaviour
{
    public abstract IItem ExtractedResource { get; set; }
    public abstract List<IItem> ItemsList { get; }
    public FarmObject ÑurrentFarmObject => _currentFarmObject;
    public SelectionWindow Selection => _selectionWindow;
    public ErrorWindow Error => _errorPanel;
    public Player Player => _player;

    [SerializeField]    protected   Slider              _productionSlider;
    [SerializeField]    protected   Slider              _waterSlider;
    [SerializeField]    protected   GameObject          _statusPanel;
                        protected   bool                _sliderUpdate = false;

    [SerializeField]    private     SelectionWindow     _selectionWindow;
    [SerializeField]    private     ErrorWindow         _errorPanel;
    [SerializeField]    private     GameObject          _buttonsPanel;
    [SerializeField]    private     AwardWindow         _awardWindowTemplate;
    [SerializeField]    private     Sprite              _expSprite;
    [SerializeField]    private     List<FarmObject>    _farmObjectList;
    [SerializeField]    private     Player              _player;
                        private     FarmObject          _currentFarmObject;

    public abstract void Fill();
    public abstract void SelectionWindow();
    public abstract IEnumerator SliderUpdate();

    public void DefiningAction()
    {
        _currentFarmObject = _farmObjectList.FirstOrDefault(item => item.Player != null);

        if (_currentFarmObject != null)
        {
            StartCoroutine(SliderUpdate());
            switch (_currentFarmObject.Occupied)
            {
                case false:
                    _player.Input.ActionEvent += SelectionWindow;
                    break;
                case true:
                    if (_currentFarmObject.CanCollect)
                        _player.Input.ActionEvent += Collecting;
                    else
                        PanelsEnable(true);
                    break;
            }
        }
        else
        {
            _sliderUpdate = false;
            PanelsEnable(false);
            _player.Input.ActionEvent -= Collecting;
            _player.Input.ActionEvent -= SelectionWindow;
        }
    }

    public void PourWater()
    {
        _currentFarmObject.PourWater();
    }

    private void PanelsEnable(bool state)
    {
        _statusPanel.SetActive(state);
        _buttonsPanel.SetActive(state);
    }

    private void Collecting()
    {
        _player.Input.ActionEvent -= Collecting;
        PanelsEnable(false);
        _currentFarmObject.Collecting();
        StartCoroutine(Awards());
    }

    private IEnumerator Awards()
    {
        Instantiate(_awardWindowTemplate, transform).Init(_currentFarmObject.Harvest.ToString(), _currentFarmObject.ÑurrentObject.UiIcon);
        yield return new WaitForSeconds(1.5f);
        Instantiate(_awardWindowTemplate, transform).Init(_currentFarmObject.Experience.ToString(), _expSprite);
    }
}
