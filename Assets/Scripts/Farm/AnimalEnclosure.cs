using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimalEnclosure : MonoBehaviour
{
    public int Level => _level;
    public float Production => _production;
    public float Water => _water;
    public float Food => _food;
    public bool Occupied => _occupied;
    public bool CanCollect => _canCollect;
    public Animal ÑurrentPopulation => _currentAnimals;
    public PlayerItems PlayerItems => _playerItems;


    private int _level = 0;
    private float _production = 0f;
    private float _water = 0f;
    private float _food = 0f;
    private bool _occupied = false;
    private bool _canCollect = false;
    private Animal _currentAnimals;
    private PlayerItems _playerItems;
    [SerializeField] private UnityEvent Events;

    public void Fill(Animal animalName, Item food)
    {
        if(_playerItems.Gold.Count > animalName.Price && _playerItems.Bucket.Count > 0 && food.Count >= 3)
        {
            _water = _playerItems.Bucket.Count;
            _playerItems.Bucket.Count = 0f;
            _food = 1f;
            food.Count -= 3f;
            _playerItems.Gold.Count -= animalName.Price;
            _currentAnimals = animalName;
            _occupied = true;
            StartCoroutine(ProcessOfGrowth());
            Events?.Invoke();
        }
    }
 
    private IEnumerator ProcessOfGrowth()
    {
        float productionMultiplier = 1;
        while (_production < 1)
        {
            productionMultiplier = (_food <= 0 || _water <= 0) ? -1f : 1f;

            _production = 0f;
            _food = 1f;
            _water = _playerItems.Bucket.Count;
            yield return new WaitForSeconds(1f);
        }
        _canCollect = true;
    }

    public void Collecting()
    {

    }

    public void PourWater(float value)
    {
        _water += value;
    }

    public void Saturate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<Outline>().enabled = true;
            _playerItems = other.GetComponent<PlayerItems>();
            Events?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Outline>().enabled = false;
            _playerItems = null;
            Events?.Invoke();
        }
    }
}
