using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectionWindow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _buttonTemplate;
    [SerializeField] private FarmUI _farmUi;
    private List<IItem> _itemList;

    public void Init(List<IItem> itemList)
    {
        _itemList = itemList;
    }

    private void OnDisable()
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);
    }

    private void OnEnable()
    {
        _itemList.ForEach(item =>
        {
            var seed = Instantiate(_buttonTemplate, _container);
            seed.gameObject.name = item.Name;
            seed.GetComponent<ISelectionButton>().Init(_farmUi, item);
        });
    }
}


