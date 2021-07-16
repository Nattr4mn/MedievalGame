using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : Loader<PlayerResources>
{
    public List<AssetItem> ItemList => itemList;
    public List<AssetItem> SeedsList => seedsList;
    public int Gold => gold;

    public string currentFarmingCrop;

    [SerializeField] private List<AssetItem> itemList;
    [SerializeField] private List<AssetItem> seedsList;
    

    private int gold = 0;


    public void ReplenishStocks(string name, int count)
    {
        itemList.ForEach(item =>
        {
            if (item.Name == name)
            {
                item.ItemCount += count;
            }
        });

    }
}

