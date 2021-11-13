//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.UI;

//public class EnclosureUI : AbstractFarmUI
//{
//    [SerializeField] private protected Slider _foodSlider;

//    public void AddFood()
//    {
//        AnimalProduct animal = (AnimalProduct)—urrentFarmObject.—urrentContent.Product;
//        AnimalEnclosure enclosure = (AnimalEnclosure)—urrentFarmObject;

//        if (animal.Food—onsumed.Quantity >= 10f)
//        {
//            enclosure.AddFood(1f);
//        }
//        else if (animal.Food—onsumed.Quantity > 0 && animal.Food—onsumed.Quantity < 10)
//        {
//            enclosure.AddFood(animal.Food—onsumed.Quantity / 10f);
//        }
//        else
//        {
//            ShowError("ÕÂ‰ÓÒÚ‡ÚÓ˜ÌÓ ÍÓÏ‡ ‰Îˇ ÊË‚ÓÚÌ˚ı!");
//        }
//    }

//    public override IEnumerator SliderUpdateCoroutine()
//    {
//        AnimalEnclosure enclosure = (AnimalEnclosure)—urrentFarmObject;
//        while (—urrentFarmObject != null && —urrentFarmObject?.—urrentContent.ProductionStage < 1f)
//        {
//            SliderUpdate();
//            _foodSlider.value = enclosure.Food;
//            yield return new WaitForSeconds(0.01f);
//        }

//        PanelsEnable(false);
//    }
//}
