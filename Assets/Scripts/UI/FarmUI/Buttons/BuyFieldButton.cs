using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyFieldButton : MonoBehaviour
{
    [SerializeField] private float              _activationLevel;
    [SerializeField] private float              _buildingTime;
    [SerializeField] private float              _price;
    [SerializeField] private AbstractFarmObject _farmObject;
    [SerializeField] private Button             _button;
    [SerializeField] private GameObject         _upPanel;
    [SerializeField] private ErrorWindow        _errorWindow;
    [SerializeField] private Player             _player;

    private void OnEnable()
    {
        if(_player.Characteristics.Level.Value >= _activationLevel)
            _button.enabled = true;
        else
            _button.enabled = false;
    }

    public void Action()
    {
        if(_player.Items.Gold.Value >= _price)
        {
            StartCoroutine(Building());
            _player.Items.Gold.Value -= _price;
        }
        else
        {
            _errorWindow.gameObject.SetActive(true);
            _errorWindow.Init("Недостаточно золота!");
        }
    }


    private IEnumerator Building()
    {
        yield return new WaitForSeconds(_buildingTime * 1f);
        _farmObject.IsActive = true;
    }
}
