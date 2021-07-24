using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public List<Item> ItemsList => _itemsList;
    public Item Meal => _meal;
    public Item Gold => _gold;
    public Item Bucket => _bucket;


    [SerializeField] private List<Item> _itemsList;
    [SerializeField] private Item _meal;
    [SerializeField] private Item _gold;
    [SerializeField] private Item _bucket;

    public void FillBucket()
    {
        _bucket.Count = Random.Range(0.5f, 1f);
    }

    public IItem GetItem(string name)
    {
        return _itemsList.FirstOrDefault(item => item.Name == name);
    }

    public void ReplenishStocks(string name, int count)
    {
        foreach (var item in _itemsList)
        {
            if (item.Name == name)
                item.Count += count;
        }
    }

}

