using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GardensUI : MonoBehaviour
{
    //public string CurrentSeed { get => _currentSeed; set { _currentSeed = value; } }
    //public string CurrentCrop { get => _currentCrop; set { _currentCrop = value; } }

    //[SerializeField] private SeedSelectionWindow _seedSelectionWindow;
    //[SerializeField] private Slider _growthRateSlider;
    //[SerializeField] private Slider _irrigationLevelSlider;
    //[SerializeField] private Button _buttonWatering;
    //private string _currentCrop;
    //private string _currentSeed;
    //private bool _sliderUpdate = false;

    //public void Planting()
    //{
    //    UIManager.Instance.ActionEvent -= SeedsPanel;
    //    _seedSelectionWindow.gameObject.SetActive(false);
    //    Garden.CurrentGarden.Planting(_currentSeed, _currentCrop);
    //}

    //public void Watering()
    //{
    //    Garden.CurrentGarden.Watering();
    //}

    //public void DefiningAction()
    //{
    //    if(Garden.CurrentGarden != null)
    //    {
    //        switch (Garden.CurrentGarden.IsSown)
    //        {
    //            case false:
    //                UIManager.Instance.ActionEvent += SeedsPanel;
    //                WateringButtonState(false);
    //                SliderStateShow(false);
    //                break;
    //            case true:
    //                if (Garden.CurrentGarden.CanCollect)
    //                {
    //                    UIManager.Instance.ActionEvent += Gathering;
    //                    WateringButtonState(false);
    //                }
    //                else
    //                {
    //                    WateringButtonState(true);
    //                    SliderStateShow(true);
    //                    SliderState();
    //                }
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        WateringButtonState(false);
    //        SliderStateShow(false);
    //        UIManager.Instance.ActionEvent -= Gathering;
    //        UIManager.Instance.ActionEvent -= SeedsPanel;
    //    }
    //}

    //private void SeedsPanel()
    //{
    //    UIManager.Instance.ActionEvent -= SeedsPanel;
    //    _seedSelectionWindow.gameObject.SetActive(true);
    //}

    //private void Gathering()
    //{
    //     Garden.CurrentGarden.Gathering();
    //    SliderStateShow(false);
    //}

    //private void WateringButtonState(bool waterState)
    //{
    //    _buttonWatering.gameObject.SetActive(waterState);
    //}

    //private void SliderStateShow(bool state)
    //{
    //    _growthRateSlider.gameObject.SetActive(state);
    //    _irrigationLevelSlider.gameObject.SetActive(state);
    //    _sliderUpdate = state;
    //    if (state)
    //        StartCoroutine(SliderUpdate());
    //}

    //private void SliderState()
    //{
    //    Vector3 newPos = Camera.main.WorldToScreenPoint(Garden.CurrentGarden.transform.position);

    //    _irrigationLevelSlider.value = Garden.CurrentGarden.IrrigationLevel;
    //    _growthRateSlider.value = Garden.CurrentGarden.GrowthRate;

    //    newPos.y += 25f;
    //    _growthRateSlider.GetComponent<RectTransform>().position = newPos;
    //    newPos.y -= 50f;
    //    _irrigationLevelSlider.GetComponent<RectTransform>().position = newPos;
    //}

    //private IEnumerator SliderUpdate()
    //{
    //    while(_sliderUpdate)
    //    {
    //        SliderState();
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
}
