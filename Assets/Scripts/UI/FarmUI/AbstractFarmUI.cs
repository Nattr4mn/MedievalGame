using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractFarmUI : MonoBehaviour
{
    public AbstractFarmObject —urrentFarmObject => _currentFarmObject;
    public SelectionWindow Selection => _selectionWindow;
    public ErrorWindow Error => _errorPanel;
    public Player Player => _player;

    [SerializeField] private protected Slider _productionSlider;
    [SerializeField] private protected Slider _waterSlider;
    [SerializeField] private protected GameObject _statusPanel;

    [SerializeField] private SelectionWindow _selectionWindow;
    [SerializeField] private ErrorWindow _errorPanel;
    [SerializeField] private GameObject _buttonsPanel;
    [SerializeField] private List<AbstractFarmObject> _farmObjectList;
    [SerializeField] private Player _player;
    private AbstractFarmObject _currentFarmObject;

    public abstract void Fill(string objectName);
    public abstract void SelectionWindow();
    public abstract IEnumerator SliderUpdate();

    public void DefiningAction(InteractiveObject interactiveObject)
    {
        if (interactiveObject != null)
        {
            _currentFarmObject = interactiveObject.gameObject.GetComponent<AbstractFarmObject>();

            if (_currentFarmObject.—urrentContent != null)
                StartCoroutine(SliderUpdate());

            switch (_currentFarmObject.Occupied)
            {
                case false:
                    InputUI.Instance.Action += SelectionWindow;
                    break;
                case true:
                    if (_currentFarmObject.—urrentContent.CanCollect)
                        InputUI.Instance.Action += Collecting;
                    else
                        PanelsEnable(true);
                    break;
            }
        }
        else
        {
            PanelsEnable(false);
            _currentFarmObject = null;
            InputUI.Instance.Action -= Collecting;
            InputUI.Instance.Action -= SelectionWindow;
        }

    }

    public void PourWater()
    {
        var bucketValue = _player.Items.Bucket;
        if (_player.Items.TryEmptyTheBucket())
        {
            _currentFarmObject.AddWater(bucketValue);
        }
        else
        {
            _errorPanel.Show("Õ‡ÔÓÎÌËÚÂ ‚Â‰Ó!");
        }
    }

    public void PanelsEnable(bool state)
    {
        _statusPanel.SetActive(state);
        _buttonsPanel.SetActive(state);
    }

    private void Collecting()
    {
        var playerLevel = _player.Level.Level;
        var playerEnergy = _player.NaturalNeeds.Energy;
        var playerLuck= _player.Characteristics.Luck.Value;
        int experience = 0;
        Player.Input.Collecting();

        InputUI.Instance.Action -= Collecting;
        PanelsEnable(false);
        var product = _currentFarmObject.Collecting(playerLevel, playerLuck, playerEnergy, out experience);
        _player.Level.AddExperience(experience);

        var harvestTuple = new Tuple<Sprite, float>(product.Item1.UIIcon, product.Item2);
        var expTuple = new Tuple<Sprite, float>(InputUI.Instance.Reward.ExpIcon, experience);
        InputUI.Instance.Reward.ShowRewards(harvestTuple, expTuple);
    }
}
