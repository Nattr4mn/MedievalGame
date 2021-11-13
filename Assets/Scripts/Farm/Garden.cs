//using System;
//using System.Collections;
//using System.Linq;
//using UnityEngine;

//[RequireComponent(typeof(GardenData))]
//public class Garden : AbstractFarmObject
//{
//    //private float _growthTime;
//    //private float _timeToDehumidification;

//    //public override void Init()
//    //{ 
//    //    _growthTime = ProductionTime;
//    //    _timeToDehumidification = ProductionTime / 3f;
//    //    if (Level.CurrentLevel > 0)
//    //    {
//    //        _growthTime = ProductionTime / (Level.CurrentLevel / Level.MaxLevel * 2);
//    //    }
//    //}

//    //public override Tuple<IFarmProduct, int> Collecting(int playerLevel, int playerLuck, float playerEnergy, out float playerExperience)
//    //{
//    //    SeedProduct product = (SeedProduct)ÑurrentContent.Product;
//    //    var seed = UnityEngine.Random.Range(8f, 16f) + playerLuck;
//    //    product.Quantity += (int)seed;
//    //    return base.Collecting(playerLevel, playerLuck, playerEnergy, out playerExperience);
//    //}

//    //public override bool TryFill(string productName, float water)
//    //{
//    //    ÑurrentContent = (GardenContent)ContentList.Where(content => content.Product.ProductName == productName).FirstOrDefault();

//    //    SeedProduct seed = (SeedProduct)ÑurrentContent.Product;
//    //    if (seed.Quantity >= 10)
//    //    {
//    //        seed.Quantity -= 10;
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

//    //private IEnumerator ProcessOfGrowth()
//    //{
//    //    while (!ÑurrentContent.CanCollect && Occupied)
//    //    {
//    //        yield return new WaitForSeconds(1f/30f);

//    //        if (WaterLevel > 0)
//    //        {
//    //            AddWater(-(1f / _timeToDehumidification));
//    //            ÑurrentContent.Growth(1f / _growthTime);
//    //        }
//    //        else if (!Spoiling.IsSpoil)
//    //        {
//    //            Spoiling.StartSpoil(() =>
//    //            {
//    //                if (WaterLevel >= 0)
//    //                    StartProcessOfGrowth();

//    //                return WaterLevel <= 0;
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