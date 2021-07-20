using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Loader<UIManager>
{
    public Button ActionButton => _action;
    public float Vertical => _joystick.Vertical;
    public float Horizontal => _joystick.Horizontal;

    public delegate void OnAction();
    public event OnAction ActionEvent;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _action;

    public void Action()
    {
        ActionEvent?.Invoke();
    }

}
