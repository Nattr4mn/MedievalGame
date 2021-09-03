using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Garden : AbstractFarmObject
{
    public override void Init(Data farmData)
    {
        throw new System.NotImplementedException();
    }

    public override Tuple<IFarmProduct, int> Collecting(int playerLevel, int playerLuck, float playerEnergy, out int playerExperience)
    {
        SeedProduct product = (SeedProduct)_currentContent.Product;
        var seed = UnityEngine.Random.Range(8f, 16f) + playerLuck;
        var harvest = UnityEngine.Random.Range(5f, 10f) + playerLuck;

        if (playerEnergy <= 0.5f)
        {
            harvest *= (0.5f + playerEnergy);
        }

        product.Quantity += (int)seed;
        product.DerivedProduct.Quantity += (int)harvest;
        playerExperience = (int)(harvest / (2 + playerLevel));
        Clear();
        InteractiveObject.Events?.Invoke(InteractiveObject);
        return new Tuple<IFarmProduct, int>(product, (int)harvest);
    }

    public override bool TryFill(string objectName, float water)
    {
        _currentContent = (GardenContent)ContentList.Where(content => content.Product.ProductName == objectName).FirstOrDefault();

        SeedProduct seed = (SeedProduct)_currentContent.Product;
        if (seed.Quantity >= 10)
        {
            _waterLevel = water;
            _occupied = true;
            _currentContent.gameObject.SetActive(true);
            seed.Quantity -= 10;
            StartProcessOfGrowth();
            InteractiveObject.Events?.Invoke(InteractiveObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void StartProcessOfGrowth()
    {
        StartCoroutine(ProcessOfGrowth());
    }

    private IEnumerator ProcessOfGrowth()
    {
        while (!_currentContent.CanCollect && _occupied)
        {
            yield return new WaitForSeconds(1f/30f);

            if (_waterLevel > 0)
            {
                _waterLevel -= 1f / ((ProductionTime) / 3f);
                _currentContent.Growth(1f / (ProductionTime));
            }
            else if (!Spoiling.IsSpoil)
            {
                Spoiling.StartSpoil(() =>
                {
                    if (_waterLevel >= 0)
                        StartProcessOfGrowth();

                    return _waterLevel <= 0;
                });
                yield break;
            }
        }

        InteractiveObject.Events.Invoke(InteractiveObject);

        if (_currentContent.CanCollect)
        {
            Spoiling.StartSpoil(() => _currentContent != null);

        }
    }
}