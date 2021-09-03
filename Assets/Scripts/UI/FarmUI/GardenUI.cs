using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GardenUI : AbstractFarmUI
{

    public override void Fill(string objectName)
    {
        InputUI.Instance.ActionButton.gameObject.SetActive(true);
        var bucket = Player.Items.Bucket;
        if (Player.Items.TryEmptyTheBucket())
        {
            if (ÑurrentFarmObject.TryFill(objectName, bucket))
            {
                Player.Input.Collecting();
                InputUI.Instance.Action -= SelectionWindow;
                Selection.gameObject.SetActive(false);
            }
            else
            {
                ShowError("Íåäîñòàòî÷íî ñåìÿí!");
            }
        }
        else
        {
            ShowError("Íåäîñòàòî÷íî âîäû!");
        }
    }

    private void ShowError(string message)
    {
        Selection.gameObject.SetActive(false);
        Error.gameObject.SetActive(true);
        Error.Show(message);
    }

    public override void SelectionWindow()
    {
        InputUI.Instance.ActionButton.gameObject.SetActive(false);
        List<IFarmProduct> products = new List<IFarmProduct>();

        ÑurrentFarmObject.ContentList.ForEach(product => 
        { 
            products.Add(product.Product); 
        });

        Selection.Init(products);
        Selection.gameObject.SetActive(true);
    }

    public override IEnumerator SliderUpdate()
    {
        while (ÑurrentFarmObject != null && ÑurrentFarmObject?.ÑurrentContent.ProductionStage < 1f)
        {
            _statusPanel.transform.position = Camera.main.WorldToScreenPoint(ÑurrentFarmObject.transform.position);
            _productionSlider.value = ÑurrentFarmObject.ÑurrentContent.ProductionStage;
            _waterSlider.value = ÑurrentFarmObject.WaterLevel;
            yield return new WaitForSeconds(0.01f);
        }

        PanelsEnable(false);
    }
}
