using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceWindow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _seedContainer;
    [SerializeField] private Transform _harvestContainer;
    [SerializeField] private ResourceLine _resourceLineTemplate;
    private bool isActive = false;

    private void OnDisable()
    {
        foreach (Transform child in _seedContainer)
            Destroy(child.gameObject);
        foreach (Transform child in _harvestContainer)
            Destroy(child.gameObject);
    }

    private void OnEnable()
    {
        Render(ItemType.SEED, _seedContainer);
        Render(ItemType.HARVEST, _harvestContainer);
    }

    public void Enable(bool state)
    {
        if (state)
            UIManager.Instance.ActionEvent += Enable;
        else
            UIManager.Instance.ActionEvent -= Enable;

    }

    private void Enable()
    {
        gameObject.SetActive(true);
        UIManager.Instance.ActionButton.gameObject.SetActive(false);
    }

    private void Render(ItemType type, Transform container)
    {
        _player.GetComponent<PlayerItems>().ItemsList.ForEach(item =>
        {
            if (item.Type == type && item.Count > 0)
            {
                var seed = Instantiate(_resourceLineTemplate, container);
                seed.gameObject.name = item.Name;
                seed.Render(item);
            }
        });
    }
}
