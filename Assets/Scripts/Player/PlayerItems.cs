using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public List<Crop> CropList => _cropList;
    public List<Item> ItemsList => _itemsList;
    public Characteristic Food => _food;
    public Characteristic Gold => _gold;
    public Characteristic Bucket => _bucket;


    [SerializeField] private List<Crop> _cropList;
    [SerializeField] private List<Item> _itemsList;
    [SerializeField] private Characteristic _food;
    [SerializeField] private Characteristic _gold;
    [SerializeField] private Characteristic _bucket;

    public void FillBucket()
    {
        _bucket.Value = Random.Range(0.5f, 1f);
    }

    public IItem GetItem(List<IItem> list, string name)
    {
        return list.FirstOrDefault(item => item.Name == name);
    }

    public void ReplenishStocks(List<IItem> list, string name, int count)
    {
        foreach (var item in list)
        {
            if (item.Name == name)
                item.Count += count;
        }
    }

}

