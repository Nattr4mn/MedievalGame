using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Loader<UIManager>
{
    public Slider irrigationLevelSlider;
    public Slider growthRateSlider;

    public void SliderSetPosition(Vector3 position)
    {
        Vector3 newPos = Camera.main.WorldToScreenPoint(position);
        newPos.y += 25f;
        growthRateSlider.GetComponent<RectTransform>().position = newPos;
        newPos.y -= 50f;
        irrigationLevelSlider.GetComponent<RectTransform>().position = newPos;
    }
}
