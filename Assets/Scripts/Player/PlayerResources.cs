using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public List<Item> ItemsList => _itemsList;
    public Item Meal => _meal;
    public Item Gold => _gold;
    public float Bucket { get => bucket; set { bucket = value; } }


    private List<Item> _itemsList;
    private Item _meal;
    private Item _gold;
    private float bucket = 0;

    public void Awake()
    {

    }

    public void FillBucket()
    {
        bucket = Random.Range(0.3f, 0.6f);
    }

    public void ReplenishStocks(string name, int count)
    {
        bool isFound = false;
        foreach (var item in _itemsList)
        {
            if (item.Name == name)
            {
                isFound = true;
                item.ItemCount += count;
            }
        }

        if(!isFound)
            AddItem(name, count);
    }

    private void AddItem(string name, int count)
    {
        foreach(var item in DataBase.Instance.Items)
        {
            if(item.Name == name)
            {
                item.ItemCount = count;
                _itemsList.Add(item);
            }
        }
    }
}

