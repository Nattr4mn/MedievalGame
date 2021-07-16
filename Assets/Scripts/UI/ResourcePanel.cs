using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private ResourceLine _resourceLineTemplate;
    [SerializeField] private Transform _container;
    private List<AssetItem> _itemList;

    public void Init(List<AssetItem> itemList)
    {
        _itemList = itemList;
    }

    public void OnEnable()
    {
        Render(_itemList);
    }

    public void Render(List<AssetItem> items)
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            if(item.ItemCount != 0)
            {
                var cell = Instantiate(_resourceLineTemplate, _container);
                cell.Render(item);
            }
        });
    }
}
