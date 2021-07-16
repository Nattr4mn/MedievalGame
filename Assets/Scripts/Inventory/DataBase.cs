using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : Loader<DataBase>
{
    [SerializeField] private List<AssetItem> _items;
    public List<AssetItem> Items => _items;
}
