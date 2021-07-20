using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SeedSelectionWindow : MonoBehaviour, IWindow
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _container;
    [SerializeField] private SeedButton _buttonTemplate;
    [SerializeField] private GardensManager _gardensManager;

    public void Close()
    {   
        foreach(Transform child in _container)
            child.GetComponent<Button>().onClick.RemoveAllListeners();

        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        _player.GetComponent<PlayerResources>().ItemsList.ForEach(item =>
        {
            var seed = Instantiate(_buttonTemplate, _container);
            seed.gameObject.name = item.Name;
            seed.Init(_gardensManager, item);
        });
    }
}


