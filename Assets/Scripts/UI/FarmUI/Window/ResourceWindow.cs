using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceWindow : MonoBehaviour
{
    [SerializeField] private Player _player;
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
        _player.GetComponent<PlayerItems>().CropList.ForEach(item =>
        {
            var crop = Instantiate(_resourceLineTemplate, _harvestContainer);
            crop.Render(item);

            var seed = Instantiate(_resourceLineTemplate, _seedContainer);
            seed.Render(item.Seed);
        });
    }

    public void Enable(bool state)
    {
        if (state)
            _player.Input.ActionEvent += Enable;
        else
            _player.Input.ActionEvent -= Enable;

    }

    private void Enable()
    {
        gameObject.SetActive(true);
        _player.Input.ActionButton.gameObject.SetActive(false);
    }
}
