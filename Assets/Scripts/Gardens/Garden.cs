using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Garden : MonoBehaviour
{
    public static Garden CurrentGarden { get; private set; }
    public float IrrigationLevel => irrigationLevel;
    public float GrowthRate => growthRate;


    [SerializeField] private UnityEvent GrowthStateEvents;
    [SerializeField] private UnityEvent SeedingEvents;
    [SerializeField] private UnityEvent GatheringEvents;
    [SerializeField] private UnityEvent GardenPositionEvents;
    [SerializeField] private UnityEvent<bool> WateringEvents;
    [SerializeField] private UnityEvent<bool> TrigerEnterEvents;
    [SerializeField] private float growthTime = 10f;
    [SerializeField] private float irrigationTime = 5f;
    private float irrigationLevel = 0f;
    private float growthRate = 0f;
    private GameObject _player;
    private bool canCollect = false;
    private bool isSown = false;
    private string currentSeedName;
    private string currentFarmCropName;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = true;
            print("Enter!");
            if (isSown && canCollect)
                GatheringEvents?.Invoke();
            else if (!isSown)
                SeedingEvents?.Invoke();

            TrigerEnterEvents?.Invoke(true);
            CurrentGarden = this;
            _player = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GardenPositionEvents?.Invoke();
            if (isSown && !canCollect)
                WateringEvents?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = false;
            TrigerEnterEvents?.Invoke(false);
            CurrentGarden = null;
        }
    }

    private void ResetValue()
    {
        isSown = false;
        canCollect = false;
        irrigationLevel = 0;
        growthRate = 0;
    }

    public void Gathering()
    {
        ResetValue();
        StartCoroutine(Processing(false));

        var harvest = (int)Random.Range(5f, 10f * (1 + _player.GetComponent<PlayerCharacteristics>().Luck.Value / 10f));
        _player.GetComponent<PlayerResources>().ReplenishStocks(currentFarmCropName, harvest);

        var seedsDropCount = (int)Random.Range(5f, 10f);
        _player.GetComponent<PlayerResources>().ReplenishStocks(currentSeedName, harvest);

    }

    public void Planting(string seed, string farmCrop)
    {
        isSown = true;
        currentFarmCropName = farmCrop;
        currentSeedName = seed;
        StartCoroutine(Processing(true));
        StartCoroutine(ProcessOfGrowth());
    }

    public void Watering(float value)
    {
        if(value > 0)
        {
            if (irrigationLevel + value > 1)
                irrigationLevel = 1;
            else
                irrigationLevel += value;
        }
    }

    private IEnumerator Processing(bool state)
    {
        _player.GetComponentInChildren<Animator>().SetBool("isRunning", false);
        _player.GetComponentInChildren<Animator>().SetTrigger("gathering");
        yield return new WaitForSeconds(3f);
        transform.Find("Crops").transform.Find(currentFarmCropName).gameObject.SetActive(state);
    }

    private IEnumerator ProcessOfGrowth()
    {
        growthRate = 0;
        StartCoroutine(DryingProcess());
        var growthMultiplier = 1f;


        while (growthRate < 1)
        {
            growthMultiplier = irrigationLevel <= 0 ? -1f : 1f;
            growthRate += growthMultiplier * (1 / (growthTime * 1f));
            yield return new WaitForSeconds(1f);

            GrowthStateEvents?.Invoke();
            if (growthRate <= 0)
            {
                transform.Find("Crops").transform.Find(currentFarmCropName).gameObject.SetActive(false);
                ResetValue();
                
            }
        }
        GrowthStateEvents?.Invoke();
        canCollect = true;
    }

    private IEnumerator DryingProcess()
    {
        irrigationLevel = 1;

        while (growthRate < 1)
        {
            irrigationLevel -= 1 / (irrigationTime * 1f);
            yield return new WaitForSeconds(1f);
        }
    }
}


[System.Serializable]
public class GrowthStateEvent : UnityEvent<bool> { }
[System.Serializable]
public class FertilizerEvent : UnityEvent<bool, bool> { }
