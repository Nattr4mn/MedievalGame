using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Garden : FarmObject
{
    public override IItem ÑurrentObject => _currentCrop;

    private Crop _currentCrop;

    public override void Collecting()
    {
        var playerEnergy = _player.NaturalNeeds.Energy.Value / _player.NaturalNeeds.Energy.MaxValue;
        ResetValue();
        StartCoroutine(Processing("Crops", _currentCrop.Name, false));
        _harvest = (int)Random.Range(5f, 10f * (1 + _player.Characteristics.Luck.Value / 10f));

        if (playerEnergy <= 0.5f)
            _harvest *= (0.5f + playerEnergy);

        _experience = _harvest / (2 + _player.Characteristics.Level.Value);
        _currentCrop.Count += _harvest;
        _currentCrop.Seed.Count += (int)Random.Range(5f, 10f);
    }

    public override void Fill(IItem item)
    {
        PlayerItems playerItems = _player.Items;
        _currentCrop = (Crop)item;

        if (_currentCrop.Seed.Count >= 10 && playerItems.Bucket.Value > 0)
        {
            _occupied = true;
            _currentCrop.Seed.Count -= 10;
            _production = 0;
            _water = playerItems.Bucket.Value;
            playerItems.Bucket.Value = 0;
            StartCoroutine(ProcessOfGrowth());
        }

        Events?.Invoke();
    }

    public override IEnumerator ProcessOfGrowth()
    {
        var productionMultiplier = 1f;
        StartCoroutine(Processing("Crops", _currentCrop.Name, true));
        yield return new WaitForSeconds(3f);

        while (_production < 1)
        {
            productionMultiplier = _water <= 0 ? -1f : 1f;
            _production += productionMultiplier * (1 / (_productionTime * 1f));
            if(_water >= 0)
                _water -= 1 / ((_productionTime / 2) * 1f);

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
}


