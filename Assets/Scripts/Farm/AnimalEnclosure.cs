using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimalEnclosure : AbstractFarmObject
{
    public override IItem ÑurrentObject => _currentAnimal;
    public float Food => _food;

    private float   _food = 0f;
    private Animal  _currentAnimal;

    public override void Fill(IItem item)
    {
        _currentAnimal = (Animal)item;
        PlayerItems playerItems = Player.Items;

        if (playerItems.Gold.Value > _currentAnimal.Price && playerItems.Bucket.Value > 0 && _currentAnimal.RequiredFood.Count >= 5)
        {
            _water = playerItems.Bucket.Value;
            StartCoroutine(Processing("Animals", _currentAnimal.Name, true));
            playerItems.Bucket.Value = 0f;
            Saturate();
            playerItems.Gold.Value -= _currentAnimal.Price;
            _occupied = true;
            StartCoroutine(ProcessOfGrowth());
            Events?.Invoke();
        }
    }

    public override void Collecting()
    {
        var playerEnergy = Player.NaturalNeeds.Energy.Value / Player.NaturalNeeds.Energy.MaxValue;
        ResetValue();
        StartCoroutine(Processing("Animals", _currentAnimal.Name, false));
        _harvest = (int)Random.Range(5f, 10f * (1 + Player.Characteristics.Luck.Value / 10f));

        if (playerEnergy <= 0.5f)
            _harvest *= (0.5f + playerEnergy);

        _experience = _harvest / (2 + Player.Characteristics.Level.Value);
        _currentAnimal.Meat.Count += _harvest;
        Events?.Invoke();
    }

    public void Saturate()
    {
        if (_currentAnimal.RequiredFood.Count >= 5f)
        {
            _food = 1f;
            _currentAnimal.RequiredFood.Count -= 5f;
        }
        else if (_currentAnimal.RequiredFood.Count >= 0)
        {
            _food = _currentAnimal.RequiredFood.Count / 5f;
            _currentAnimal.RequiredFood.Count = 0;
        }
    }

    public override IEnumerator ProcessOfGrowth()
    {
        var productionMultiplier = 1f;
        StartCoroutine(Processing("Animals", _currentAnimal.Name, true));
        yield return new WaitForSeconds(3f);

        while (_production < 1)
        {
            productionMultiplier = _water <= 0 ? -1f : 1f;
            _production += productionMultiplier * (1 / (_productionTime * 1f));
            if(_food > 0) _food -= 1 / ((_productionTime / 1.5f) * 1f);
            if (_water > 0) _water -= 1 / ((_productionTime / 2) * 1f);

            yield return new WaitForSeconds(1f);

            Events?.Invoke();
            if (_production <= 0 && (_water <= 0 || _food <= 0))
            {
                transform.Find("Animals").transform.Find(_currentAnimal.Name).gameObject.SetActive(false);
                ResetValue();
                break;
            }
        }
        if (_production >= 1f)
            StartCoroutine(TimerToDestroy());
    }

    public override IEnumerator TimerToDestroy()
    {
        _canCollect = true;
        Events?.Invoke();
        yield return new WaitForSeconds(360f);
        if (_canCollect)
        {
            transform.Find("Animals").transform.Find(_currentAnimal.Name).gameObject.SetActive(false);
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
