using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MedievalGame.Player;

public abstract class AbstractFarmUI : MonoBehaviour
{
    //public AbstractFarmObject ÑurrentFarmObject => _currentFarmObject;
    //public SelectionWindow Selection => _selectionWindow;
    //public ErrorWindow Error => _errorPanel;
    ////public Player Player => _player;
    //public Slider ProductionSlider => _productionSlider;
    //public Slider WaterSlider => _waterSlider;
    //public GameObject StatusPanel => _statusPanel;

    //[SerializeField] private Slider _productionSlider;
    //[SerializeField] private Slider _waterSlider;
    //[SerializeField] private GameObject _statusPanel;

    //[SerializeField] private SelectionWindow _selectionWindow;
    //[SerializeField] private ErrorWindow _errorPanel;
    //[SerializeField] private GameObject _buttonsPanel;
    //[SerializeField] private List<AbstractFarmObject> _farmObjectList;
    ////[SerializeField] private Player _player;
    //private AbstractFarmObject _currentFarmObject;

    //public abstract IEnumerator SliderUpdateCoroutine();

    //public void DefiningAction(InteractiveObject interactiveObject)
    //{
    //    if (interactiveObject != null)
    //    {
    //        _currentFarmObject = interactiveObject.gameObject.GetComponent<AbstractFarmObject>();

    //        if (_currentFarmObject.ÑurrentContent != null)
    //            StartCoroutine(SliderUpdateCoroutine());

    //        switch (_currentFarmObject.Occupied)
    //        {
    //            case false:
    //                InputUI.Instance.Action += SelectionWindow;
    //                break;
    //            case true:
    //                if (_currentFarmObject.ÑurrentContent.CanCollect)
    //                    InputUI.Instance.Action += Collecting;
    //                else
    //                    PanelsEnable(true);
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        PanelsEnable(false);
    //        _currentFarmObject = null;
    //        InputUI.Instance.Action -= Collecting;
    //        InputUI.Instance.Action -= SelectionWindow;
    //    }

    //}

    //public void SelectionWindow()
    //{
    //    InputUI.Instance.ActionButton.gameObject.SetActive(false);
    //    List<IFarmProduct> products = new List<IFarmProduct>();

    //    ÑurrentFarmObject.ContentList.ForEach(product =>
    //    {
    //        products.Add(product.Product);
    //    });

    //    Selection.Init(products);
    //    Selection.gameObject.SetActive(true);
    //}

    //public void Fill(string objectName)
    //{
    //    //InputUI.Instance.ActionButton.gameObject.SetActive(true);
    //    //var bucket = Player.Items.Bucket;
    //    //if (Player.Items.TryEmptyTheBucket())
    //    //{
    //    //    if (ÑurrentFarmObject.TryFill(objectName, bucket))
    //    //    {
    //    //        Player.Input.Collecting();
    //    //        InputUI.Instance.Action -= SelectionWindow;
    //    //        Selection.gameObject.SetActive(false);
    //    //    }
    //    //    else
    //    //    {
    //    //        ShowError("Íåäîñòàòî÷íî ðåñóðñîâ!");
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    ShowError("Íåäîñòàòî÷íî âîäû!");
    //    //}
    //}

    //public void PourWater()
    //{
    //    //var bucketValue = _player.Items.Bucket;
    //    //if (_player.Items.TryEmptyTheBucket())
    //    //{
    //    //    _currentFarmObject.AddWater(bucketValue);
    //    //}
    //    //else
    //    //{
    //    //    _errorPanel.Show("Íàïîëíèòå âåäðî!");
    //    //}
    //}

    //public void PanelsEnable(bool state)
    //{
    //    _statusPanel.SetActive(state);
    //    _buttonsPanel.SetActive(state);
    //}

    //public void ShowError(string message)
    //{
    //    Selection.gameObject.SetActive(false);
    //    Error.gameObject.SetActive(true);
    //    Error.Show(message);
    //}

    //public void SliderUpdate()
    //{
    //    _statusPanel.transform.position = Camera.main.WorldToScreenPoint(ÑurrentFarmObject.transform.position);
    //    _productionSlider.value = ÑurrentFarmObject.ÑurrentContent.ProductionStage;
    //    _waterSlider.value = ÑurrentFarmObject.WaterLevel;
    //}

    //private void Collecting()
    //{
    //    //var playerLevel = _player.Level.Level;
    //    //var playerEnergy = _player.NaturalNeeds.Energy;
    //    //var playerLuck= _player.Characteristics.Luck.Value;
    //    //float experience = 0;
    //    //Player.Input.Collecting();

    //    //InputUI.Instance.Action -= Collecting;
    //    //PanelsEnable(false);
    //    //var product = _currentFarmObject.Collecting(playerLevel, playerLuck, playerEnergy, out experience);
    //    //_player.Level.AddExperience(experience);

    //    //var harvestTuple = new Tuple<Sprite, float>(product.Item1.UIIcon, product.Item2);
    //    //var expTuple = new Tuple<Sprite, float>(InputUI.Instance.Reward.ExpIcon, experience);
    //    //InputUI.Instance.Reward.ShowRewards(harvestTuple, expTuple);
    //}
}
