using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SeedSelectionWindow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _container;
    [SerializeField] private SeedButton _buttonTemplate;
    [SerializeField] private GardensUIManager _gardensManager;

    private void OnDisable()
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);
    }

    private void OnEnable()
    {
        _player.GetComponent<PlayerItems>().ItemsList.ForEach(item =>
        {
            if (item.Type == ItemType.SEED && item.Count > 0)
            {
                var seed = Instantiate(_buttonTemplate, _container);
                seed.gameObject.name = item.Name;
                seed.Init(_gardensManager, item);
            }
        });
    }
}


