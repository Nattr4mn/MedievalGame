using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GardenUI : FarmUI
{
    public override IItem ExtractedResource { get => _crop; set => _crop = value; }
    public override List<IItem> ItemsList => _itemsList;

    [SerializeField] private List<IItem> _itemsList;
    [SerializeField] private IItem _crop;

    public override void Fill()
    {
        Crop item = (Crop)_crop;
        Player.Input.ActionButton.gameObject.SetActive(true);
        if (Player.Items.Bucket.Value > 0 && item.Count >= 10)
        {
            Player.Input.PlayerAction -= SelectionWindow;
            Selection.gameObject.SetActive(false);
            ÑurrentFarmObject.Fill(_crop);
        }
        else
        {
            Selection.gameObject.SetActive(false);
            Error.gameObject.SetActive(true);
            Error.Init("Íåäîñòàòî÷íî ðåñóðñîâ!");
        }
    }

    public override void SelectionWindow()
    {
        Player.Input.ActionButton.gameObject.SetActive(false);
        _itemsList = Player.Items.CropList.Select(crop => (IItem)crop).ToList();
        print(_itemsList[0].Name);
        Selection.Init(_itemsList);
        Selection.gameObject.SetActive(true);
    }

    public override IEnumerator SliderUpdate()
    {
        _sliderUpdate = true;
        while (_sliderUpdate)
        {
            _statusPanel.transform.position = Camera.main.WorldToScreenPoint(ÑurrentFarmObject.transform.position);
            _productionSlider.value = ÑurrentFarmObject.Production;
            _waterSlider.value = ÑurrentFarmObject.Water;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
