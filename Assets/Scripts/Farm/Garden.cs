using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Garden : MonoBehaviour
{
    public static Garden CurrentGarden { get; private set; }
    public float IrrigationLevel => _irrigationLevel;
    public float GrowthRate => _growthRate;
    public bool IsSown => _isSown;
    public bool CanCollect => _canCollect;


    [SerializeField] private UnityEvent GardenEvent;
    [SerializeField] private float _growthTime = 10f;
    [SerializeField] private float _irrigationTime = 5f;
    private float _irrigationLevel = 0f;
    private float _growthRate = 0f;
    private int _gardenLevel = 0;
    private GameObject _player;
    private bool _canCollect = false;
    private bool _isSown = false;
    private string _currentSeedName;
    private string _currentFarmCropName;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = true;
            CurrentGarden = this;
            GardenEvent?.Invoke();
            _player = other.gameObject;
            print(_player.GetComponent<PlayerItems>().Bucket.Count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = false;
            CurrentGarden = null;
            GardenEvent?.Invoke();
        }
    }

    private void ResetValue()
    {
        _isSown = false;
        _canCollect = false;
        _irrigationLevel = 0;
        _growthRate = 0;
    }

    public void Gathering()
    {
        ResetValue();
        StartCoroutine(Processing(false));

        var harvest = (int)Random.Range(5f, 10f * (1 + _player.GetComponent<PlayerCharacteristics>().Luck.Value / 10f));
        _player.GetComponent<PlayerItems>().ReplenishStocks(_currentFarmCropName, harvest);

        var seedsDropCount = (int)Random.Range(5f, 10f);
        _player.GetComponent<PlayerItems>().ReplenishStocks(_currentSeedName, harvest);

    }

    public void Planting(string seed, string farmCrop)
    {
        if (_player.GetComponent<PlayerItems>().GetItemCount(seed)?.Count >= 10)
        {
            _isSown = true;
            _currentFarmCropName = farmCrop;
            _currentSeedName = seed;
            StartCoroutine(Processing(true));
            StartCoroutine(ProcessOfGrowth());
        }
        else
        {
            GardenEvent?.Invoke();
        }
    }

    public void Watering()
    {
        var value = _player.GetComponent<PlayerItems>().Bucket.Count;
        _player.GetComponent<PlayerItems>().Bucket.Count = 0;

        _irrigationLevel += value;

        if (_irrigationLevel > 1)
            _irrigationLevel = 1;
    }

    private IEnumerator Processing(bool state)
    {
        _player.GetComponentInChildren<Animator>().SetBool("isRunning", false);
        _player.GetComponentInChildren<Animator>().SetTrigger("gathering");
        yield return new WaitForSeconds(3f);
        transform.Find("Crops").transform.Find(_currentFarmCropName).gameObject.SetActive(state);
    }

    private IEnumerator ProcessOfGrowth()
    {
        yield return new WaitForSeconds(3f);
        _growthRate = 0;
        StartCoroutine(DryingProcess());
        var growthMultiplier = 1f;


        while (_growthRate < 1)
        {
            growthMultiplier = _irrigationLevel <= 0 ? -1f : 1f;
            _growthRate += growthMultiplier * (1 / (_growthTime * 60f));
            yield return new WaitForSeconds(1f);

            GardenEvent?.Invoke();
            if (_growthRate <= 0)
            {
                transform.Find("Crops").transform.Find(_currentFarmCropName).gameObject.SetActive(false);
                ResetValue();
            }
        }
        GardenEvent?.Invoke();
        _canCollect = true;
    }

    private IEnumerator DryingProcess()
    {
        _irrigationLevel = 1;

        while (_isSown)
        {
            _irrigationLevel -= 1 / (_irrigationTime * 60f);
            yield return new WaitForSeconds(1f);
            GardenEvent?.Invoke();
        }
    }
}


[System.Serializable]
public class GrowthStateEvent : UnityEvent<bool> { }
[System.Serializable]
public class FertilizerEvent : UnityEvent<bool, bool> { }
