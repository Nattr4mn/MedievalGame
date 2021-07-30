using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpFieldButton : MonoBehaviour
{
    [SerializeField] private FarmObject      _farmObject;
    [SerializeField] private float           _priceToUp;
    [SerializeField] private ErrorWindow     _errorWindow;
    [SerializeField] private Player          _player;

    private void Start()
    {
        if (_farmObject.Level == 5)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }

    public void LevelUp()
    {
        if(_player.Items.Gold.Value >= _priceToUp)
        {
            _farmObject.Level += 1;
            _player.Items.Gold.Value -= _priceToUp;
            _priceToUp *= 2;
            if(_farmObject.Level == 5)
                gameObject.SetActive(false);
        }
        else
        {
            _errorWindow.gameObject.SetActive(true);
            _errorWindow.Init("Недостаточно золота для улучшения!");
        }
    }
}
