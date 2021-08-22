using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Garden : AbstractFarmObject
{
    public override IItem ÑurrentObject => _currentCrop;
    private Save<GardenData> _saveData;
    private Crop _currentCrop;

    private void Awake()
    {
        LoadGarden();
    }

    public override void Collecting()
    {
        var playerEnergy = Player.NaturalNeeds.Energy.Value / Player.NaturalNeeds.Energy.MaxValue;
        ResetValue();
        StartCoroutine(Processing("Crops", _currentCrop.Name, false));
        _harvest = (int)UnityEngine.Random.Range(5f, 10f * (1 + Player.Characteristics.Luck.Value / 10f));

        if (playerEnergy <= 0.5f)
            _harvest *= (0.5f + playerEnergy);

        _experience = _harvest / (2 + Player.Characteristics.Level.Value);
        _currentCrop.Count += _harvest;
        _currentCrop.Seed.Count += (int)UnityEngine.Random.Range(5f, 10f);
    }

    public override void Fill(IItem item)
    {
        PlayerItems playerItems = Player.Items;
        _currentCrop = (Crop)item;

        if (_currentCrop.Seed.Count >= 10 && playerItems.Bucket.Value > 0)
        {
            _occupied = true;
            _currentCrop.Seed.Count -= 10;
            _production = 0;
            _water = playerItems.Bucket.Value;
            playerItems.Bucket.Value = 0;
            StartCoroutine(Processing("Crops", _currentCrop.Name, true));
            StartCoroutine(ProcessOfGrowth());
        }

        Events?.Invoke();
    }

    public override IEnumerator ProcessOfGrowth()
    {
        var productionMultiplier = 1f;
        yield return new WaitForSeconds(3f);

        while (_production < 1)
        {
            productionMultiplier = _water <= 0 ? -1f : 1f;
            _production += productionMultiplier * (1 / _productionTime);
            if(_water >= 0)
                _water -= 1 / (_productionTime / 2);

            yield return new WaitForSeconds(1f);

            Events?.Invoke();
            if (_production <= 0 && _water <= 0)
            {
                transform.Find("Crops").transform.Find(_currentCrop.Name).gameObject.SetActive(false);
                ResetValue();
                break;
            }
        }
        if(_production >= 1f)
            StartCoroutine(TimerToDestroy());
    }

    public override IEnumerator TimerToDestroy()
    {
        _canCollect = true;
        Events?.Invoke();
        yield return new WaitForSeconds(360f);
        if(_canCollect)
        {
            transform.Find("Crops").transform.Find(_currentCrop.Name).gameObject.SetActive(false);
            ResetValue();
        }
    }

    private void ResetValue()
    {
        _occupied = false;
        _canCollect = false;
        _water = 0;
        _production = 0;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        SaveGarden();
    }
#endif
    private void OnApplicationQuit()
    {
        SaveGarden();
    }

    private void SaveGarden()
    {
        GardenData gardenData = new GardenData()
        {
            saveTime = DateTime.Now.ToString(),
            production = Production,
            water = Water,
            occupied = Occupied,
            canCollect = CanCollect,
            currentCrop = _currentCrop
        };
        _saveData.SaveData(gardenData);
    }
    
    private void LoadGarden()
    {
        _saveData = new Save<GardenData>(gameObject.name);
        _saveData.LoadData();
        if (_saveData.Data != null)
        {
            DateTime exitTime = DateTime.Parse(_saveData.Data.saveTime);
            _production = _saveData.Data.production;
            _water = _saveData.Data.water;
            _occupied = _saveData.Data.occupied;
            _canCollect = _saveData.Data.canCollect;
            _currentCrop = _saveData.Data.currentCrop;


            int timeProduction = (int)((_productionTime - (_productionTime * _production)));
            int timeWater = (int)(((_productionTime / 2) - ((_productionTime / 2) * _water)));
            DateTime currentTime = DateTime.Now;
            TimeSpan timeDifference = currentTime - exitTime;
            int seconds = (int)timeDifference.TotalSeconds;

            if (_occupied)
            {
                if (timeWater >= seconds)
                {
                    timeWater = timeWater - seconds;
                    _water -= (1 / (_productionTime / 2)) * seconds;
                    _production += (1 / _productionTime) * seconds;
                    if (_production >= 1)
                    {
                        _production = 1f;
                        _canCollect = true;
                        transform.Find("Crops").transform.Find(_currentCrop.Name).gameObject.SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(ProcessOfGrowth());
                        transform.Find("Crops").transform.Find(_currentCrop.Name).gameObject.SetActive(true);
                    }

                }
                else
                {
                    var differenceSeconds = timeWater - seconds;
                    _water = 0;
                    _production -= (1 / _productionTime) * differenceSeconds;
                    if(_production > 0)
                    {
                        StartCoroutine(ProcessOfGrowth());
                        transform.Find("Crops").transform.Find(_currentCrop.Name).gameObject.SetActive(true);
                    }
                }
            }

        }
    }
}


