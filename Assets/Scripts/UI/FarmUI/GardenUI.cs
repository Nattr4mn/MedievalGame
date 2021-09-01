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
        if (Player.Items.Bucket.Value > 0)
        {
            if (�urrentFarmObject.TryFill(objectName, Player.Items.Bucket.Value))
            {
                Player.Input.Collecting();
                InputUI.Instance.Action -= SelectionWindow;
                Player.Items.Bucket.Value = 0f;
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
        while (�urrentFarmObject != null)
        {
            _statusPanel.transform.position = Camera.main.WorldToScreenPoint(�urrentFarmObject.transform.position);
            _productionSlider.value = �urrentFarmObject.�urrentContent.ProductionStage;
            _waterSlider.value = �urrentFarmObject.WaterLevel;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
