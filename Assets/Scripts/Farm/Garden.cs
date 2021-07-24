using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Garden : FarmObject
{
    public override int Level => _level;
    public override float Production => _production;
    public override float ProductionTime => _productionTime;
    public override float Harvest => _harvest;
    public override float Experience => _experience;
    public override bool Occupied => _occupied;
    public override bool CanCollect => _canCollect;
    public override IItem ÑurrentObject => _currentSeedName;
    public IItem ÑurrentHarvest => _currentFarmCropName;

    [SerializeField] private float _productionTime = 24f;
    private int _level = 0;
    private float _production = 0f;
    public float _harvest;
    public float _experience;
    private bool _occupied = false;
    private bool _canCollect = false;
    private Item _currentSeedName;
    private Item _currentFarmCropName;

    public override void Collecting()
    {
        var playerEnergy = Player.Characteristics.Energy.Value / Player.Characteristics.Energy.MaxValue;
        ResetValue();
        StartCoroutine(Processing("Crops", _currentFarmCropName.Name, false));
        _harvest = (int)Random.Range(5f, 10f * (1 + Player.Characteristics.Luck.Value / 10f));

        if (playerEnergy <= 0.5f)
            _harvest *= (0.5f + playerEnergy);

        _experience = _harvest / (2 + Player.Characteristics.Level.Value);
        _currentFarmCropName.Count += _harvest;
        _currentSeedName.Count += (int)Random.Range(5f, 10f);
    }

    public override void Fill(IItem firstItem, IItem secondItem)
    {
        PlayerItems playerItems = Player.Items;
        _currentSeedName = (Item)firstItem;
        _currentFarmCropName = (Item)secondItem;

        if (_currentSeedName.Count >= 10 && playerItems.Bucket.Count > 0)
        {
            _occupied = true;
            _currentSeedName.Count -= 10;
            _water = playerItems.Bucket.Count;
            playerItems.Bucket.Count = 0;
            StartCoroutine(ProcessOfGrowth());
        }

        Events?.Invoke();
    }

    public override IEnumerator ProcessOfGrowth()
    {
        var productionMultiplier = 1f;
        StartCoroutine(Processing("Crops", _currentFarmCropName.Name, true));
        yield return new WaitForSeconds(3f);
        _production = 0;


        while (_production < 1)
        {
            productionMultiplier = _water <= 0 ? -1f : 1f;
            _production += productionMultiplier * (1 / (_productionTime * 1f));
            _water -= 1 / ((_productionTime / 2) * 1f);
            yield return new WaitForSeconds(1f);

            Events?.Invoke();
            if (_production <= 0 && _water <= 0)
            {
                transform.Find("Crops").transform.Find(_currentFarmCropName.Name).gameObject.SetActive(false);
                ResetValue();
            }
        }
        _canCollect = true;
        Events?.Invoke();
    }

    private void ResetValue()
    {
        _occupied = false;
        _canCollect = false;
        _water = 0;
        _production = 0;
    }
}


