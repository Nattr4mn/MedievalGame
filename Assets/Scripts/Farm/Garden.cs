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
//    //    SeedProduct product = (SeedProduct)ĐurrentContent.Product;
//    //    var seed = UnityEngine.Random.Range(8f, 16f) + playerLuck;
//    //    product.Quantity += (int)seed;
//    //    return base.Collecting(playerLevel, playerLuck, playerEnergy, out playerExperience);
//    //}

//    //public override bool TryFill(string productName, float water)
//    //{
//    //    ĐurrentContent = (GardenContent)ContentList.Where(content => content.Product.ProductName == productName).FirstOrDefault();

//    //    SeedProduct seed = (SeedProduct)ĐurrentContent.Product;
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
//    //    while (!ĐurrentContent.CanCollect && Occupied)
//    //    {
//    //        yield return new WaitForSeconds(1f/30f);

//    //        if (WaterLevel > 0)
//    //        {
//    //            AddWater(-(1f / _timeToDehumidification));
//    //            ĐurrentContent.Growth(1f / _growthTime);
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

//    //    if (ĐurrentContent.CanCollect)
//    //    {
//    //        Spoiling.StartSpoil(() => ĐurrentContent != null);
//    //    }
//    //}
//}