//using System;
//using System.Collections;
//using System.Linq;
//using UnityEngine;

//public class AnimalEnclosure : AbstractFarmObject
//{
//    //public float Food => _food;
//    //private float _food = 0f;
//    //private float _growthTime;
//    //private float _foodTime;
//    //private float _timeToDehumidification;

//    //public override void Init()
//    //{
//    //    _growthTime = ProductionTime;
//    //    _foodTime = ProductionTime / 3f;
//    //    _timeToDehumidification = ProductionTime / 4f;
//    //    if (Level.CurrentLevel > 0)
//    //    {
//    //        _growthTime = ProductionTime - (Level.CurrentLevel / Level.MaxLevel * 2) * TimeController.Instance.FullDay;
//    //    }
//    //}

//    //public override bool TryFill(string objectName, float water)
//    //{
//    //    ÑurrentContent = (AnimalContent)ContentList.Where(content => content.Product.ProductName == objectName).FirstOrDefault();

//    //    AnimalProduct animal = (AnimalProduct)ÑurrentContent.Product;
//    //    if (animal.FoodÑonsumed.Quantity >= 10)
//    //    {
//    //        _food = 1f;
//    //        animal.FoodÑonsumed.Quantity -= 10;
//    //        Fill(water);
//    //        return true;
//    //    }
//    //    else if (animal.FoodÑonsumed.Quantity > 0)
//    //    {
//    //        _food = animal.FoodÑonsumed.Quantity / 10f;
//    //        animal.FoodÑonsumed.Quantity = 0;
//    //        Fill(water);
//    //        return true;
//    //    }
//    //    else
//    //    {
//    //        return false;
//    //    }
//    //}

//    //public override void StartProcessOfGrowth()
//    //{
//    //    StartCoroutine(ProcessOfGrowth());
//    //}

//    //public void AddFood(float value)
//    //{
//    //    if (value > 0f)
//    //        _food += value;
//    //    if (_food > 1f)
//    //        _food = 1f;
//    //}

//    //private IEnumerator ProcessOfGrowth()
//    //{
//    //    while (!ÑurrentContent.CanCollect && Occupied)
//    //    {
//    //        yield return new WaitForSeconds(1f / 30f);

//    //        if (WaterLevel > 0)
//    //        {
//    //            AddWater(-(1f / _timeToDehumidification));
//    //        }

//    //        if (_food > 0)
//    //        {
//    //            _food -= 1f / _foodTime;
//    //        }

//    //        if (WaterLevel > 0 || _food > 0)
//    //        {
//    //            ÑurrentContent.Growth(1f / _growthTime);
//    //        }
//    //        else if (!Spoiling.IsSpoil)
//    //        {
//    //            Spoiling.StartSpoil(() =>
//    //            {
//    //                if (WaterLevel >= 0 || _food >= 0)
//    //                    StartProcessOfGrowth();

//    //                return WaterLevel <= 0 || _food <= 0;
//    //            });
//    //            yield break;
//    //        }
//    //    }

//    //    InteractiveObject.Events.Invoke(InteractiveObject);

//    //    if (ÑurrentContent.CanCollect)
//    //    {
//    //        Spoiling.StartSpoil(() => ÑurrentContent != null);
//    //    }
//    //}
//}
