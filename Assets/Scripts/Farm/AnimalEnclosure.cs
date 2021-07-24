using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimalEnclosure : FarmObject
{
    public override int Level => _level;
    public override float Production => _production;
    public override float ProductionTime => _productionTime;
    public float Food => _food;
    public override bool Occupied => _occupied;
    public override bool CanCollect => _canCollect;
    public override IItem ÑurrentObject => _currentAnimals;

    public override float Harvest => throw new System.NotImplementedException();

    public override float Experience => throw new System.NotImplementedException();

    [SerializeField] private float _productionTime = 0f;
    private int _level = 0;
    private float _production = 0f;
    private float _water = 0f;
    private float _food = 0f;
    private bool _occupied = false;
    private bool _canCollect = false;
    private IItem _currentAnimals;

    public override void Fill(IItem firstItem, IItem secondItem)
    {
        Animal animal = (Animal)firstItem;
        Item food = (Item)secondItem;
        PlayerItems playerItems = Player.Items;

        if (playerItems.Gold.Count > animal.Price && playerItems.Bucket.Count > 0 && food.Count >= 3)
        {
            _water = playerItems.Bucket.Count;
            playerItems.Bucket.Count = 0f;
            _food = 1f;
            food.Count -= 3f;
            playerItems.Gold.Count -= animal.Price;
            _currentAnimals = animal;
            _occupied = true;
            StartCoroutine(ProcessOfGrowth());
            Events?.Invoke();
        }
    }
 
    public override IEnumerator ProcessOfGrowth()
    {
        PlayerItems playerItems = Player.Items;
        float productionMultiplier = 1;
        while (_production < 1)
        {
            productionMultiplier = (_food <= 0 || _water <= 0) ? -1f : 1f;

            _production = 0f;
            _food = 1f;
            _water = playerItems.Bucket.Count;
            yield return new WaitForSeconds(1f);
        }
        _canCollect = true;
    }

    public override void Collecting()
    {

    }

    public void Saturate()
    {

    }
}
