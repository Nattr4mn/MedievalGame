using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : Loader<DataBase>
{
    [SerializeField] private List<Item> _items;
    public List<Item> Items => _items;
}
