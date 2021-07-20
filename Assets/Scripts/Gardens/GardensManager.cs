using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GardensManager : MonoBehaviour
{
    public string CurrentSeed { get => currentSeed; set { currentSeed = value; } }
    public string CurrentCrop { get => currentCrop; set { currentCrop = value; } }

    [SerializeField] private SeedSelectionWindow _seedSelectionWindow;
    [SerializeField] private Slider _growthRateSlider;
    [SerializeField] private Slider _irrigationLevelSlider;
    [SerializeField] private Button _buttonWatering;
    private string currentCrop;
    private string currentSeed;

    public void Watering(float value)
    {
        Garden.CurrentGarden.Watering(0.2f);
    }

    public void Planting()
    {
        UIManager.Instance.ActionEvent -= SeedsPanel;
        _seedSelectionWindow.gameObject.SetActive(false);
        Garden.CurrentGarden.Planting(currentSeed, currentCrop);
    }

    public void Gathering()
    {
        UIManager.Instance.ActionEvent += Garden.CurrentGarden.Gathering;
    }

    public void SeedsPanel()
    {
        UIManager.Instance.ActionEvent += _seedSelectionWindow.Open;
    }









    public void WateringButtonState(bool waterState)
    {
        _buttonWatering.gameObject.SetActive(waterState);
    }

    public void SliderStateShow(bool state)
    {
        _growthRateSlider.gameObject.SetActive(state);
        _irrigationLevelSlider.gameObject.SetActive(state);
    }

    public void SliderStatePosition()
    {
        Vector3 newPos = Camera.main.WorldToScreenPoint(Garden.CurrentGarden.transform.position);
        newPos.y += 25f;
        _growthRateSlider.GetComponent<RectTransform>().position = newPos;
        newPos.y -= 50f;
        _irrigationLevelSlider.GetComponent<RectTransform>().position = newPos;
    }

    public void SliderStateValue()
    {
        _irrigationLevelSlider.value = Garden.CurrentGarden.IrrigationLevel;
        _growthRateSlider.value = Garden.CurrentGarden.GrowthRate;
    }
}
