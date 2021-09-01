using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Garden : AbstractFarmObject
{
    private void Start()
    {
        
    }

    public override void Init()
    {
        throw new System.NotImplementedException();
    }

    public override Tuple<IFarmProduct, int> Collecting(int playerLevel, float playerEnergy, out int playerExperience)
    {
        SeedProduct product = (SeedProduct)_currentContent.Product;
        var seed = UnityEngine.Random.Range(8f, 16f);
        var harvest = UnityEngine.Random.Range(5f, 10f);

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
        print(_currentContent);
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

    public override void StartSpoil(SpoilOperation RootingOperation)
    {
        StartCoroutine(Spoil(RootingOperation));
    }

    private IEnumerator ProcessOfGrowth()
    {
        while (_currentContent?.ProductionStage < 1f || _occupied)
        {
            yield return new WaitForSeconds(1f/30f);

            if (_waterLevel >= 0)
            {
                _waterLevel -= 1f / ((ProductionTime) / 3f);
                _currentContent.Growth(1f / (ProductionTime));
            }
            else
            {
                StartSpoil(Drying);
            }
        }

        if(_occupied)
        {
            StartSpoil(Rotting);
        }
    }

    private bool Rotting()
    {
        return _currentContent.CanCollect;
    }

    private bool Drying()
    {
        return _waterLevel <= 0;
    }

    private IEnumerator Spoil(SpoilOperation RootingOperation)
    {
        var rootingTime = ProductionTime / 4;

        while (_spoilTime < rootingTime)
        {
            _spoilTime += 1f;
            yield return new WaitForSeconds(1f);
            if(!RootingOperation())
            {
                break;
            }
        }
        _spoilTime = 0f;

        if (RootingOperation())
        {
            Clear();
        }
        InteractiveObject.Events?.Invoke(InteractiveObject);
    }

    private void Clear()
    {
        _waterLevel = 0f;
        _occupied = false;
        _currentContent.Execute();
        _currentContent = null;
    }
}