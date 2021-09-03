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
            if (�urrentFarmObject.TryFill(objectName, bucket))
            {
                Player.Input.Collecting();
                InputUI.Instance.Action -= SelectionWindow;
                Selection.gameObject.SetActive(false);
            }
            else
            {
                ShowError("������������ �����!");
            }
        }
        else
        {
            ShowError("������������ ����!");
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

        �urrentFarmObject.ContentList.ForEach(product => 
        { 
            products.Add(product.Product); 
        });

        Selection.Init(products);
        Selection.gameObject.SetActive(true);
    }

    public override IEnumerator SliderUpdate()
    {
        while (�urrentFarmObject != null && �urrentFarmObject?.�urrentContent.ProductionStage < 1f)
        {
            _statusPanel.transform.position = Camera.main.WorldToScreenPoint(�urrentFarmObject.transform.position);
            _productionSlider.value = �urrentFarmObject.�urrentContent.ProductionStage;
            _waterSlider.value = �urrentFarmObject.WaterLevel;
            yield return new WaitForSeconds(0.01f);
        }

        PanelsEnable(false);
    }
}
