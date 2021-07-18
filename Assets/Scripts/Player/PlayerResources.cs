using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public List<AssetItem> ItemList => itemList;
    public List<AssetItem> SeedsList => seedsList;
    public int Gold => gold;

    public string currentFarmingCrop;

    private List<AssetItem> itemList;
    private List<AssetItem> seedsList;
    private int gold = 0;

    public void Init(List<AssetItem> itemList, List<AssetItem> seedsList)
    {
        this.itemList = itemList;
        this.seedsList = seedsList;

    }

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

