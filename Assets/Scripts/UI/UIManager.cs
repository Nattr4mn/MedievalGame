using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Loader<UIManager>
{
    public Button ActionButton => _action;
    public float Vertical => _joystick.Vertical;
    public float Horizontal => _joystick.Horizontal;
    public Slider irrigationLevelSlider;
    public Slider growthRateSlider;
    public Slider thirstSlider;
    public Slider hungerSlider;
    public delegate void OnAction();
    public event OnAction actionButtonEvent;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _action;

    public void SliderSetPosition(Vector3 position)
    {
        Vector3 newPos = Camera.main.WorldToScreenPoint(position);
        newPos.y += 25f;
        growthRateSlider.GetComponent<RectTransform>().position = newPos;
        newPos.y -= 50f;
        irrigationLevelSlider.GetComponent<RectTransform>().position = newPos;
    }

    public void Action()
    {
        actionButtonEvent?.Invoke();
    }

}
