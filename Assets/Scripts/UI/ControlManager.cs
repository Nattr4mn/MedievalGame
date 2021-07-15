using UnityEngine;
using UnityEngine.UI;

public class ControlManager : Loader<ControlManager>
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _action;
    public delegate void OnAction();
    public event OnAction actionButtonEvent;

    public Button ActionButton => _action;
    public float Vertical => _joystick.Vertical;
    public float Horizontal => _joystick.Horizontal;

    public void Action()
    {
        actionButtonEvent?.Invoke();
    }
}
