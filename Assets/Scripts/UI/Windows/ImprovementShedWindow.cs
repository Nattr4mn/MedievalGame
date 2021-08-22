using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImprovementShedWindow : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _buyButtonTemplate;
    [SerializeField] private GameObject _upgradeButtonTemplate;
    [SerializeField] private List<AbstractFarmObject> _farmObjects;
    private GameObject _window;
    private List<ImprovementButton> _buttonPool = new List<ImprovementButton>();

    private void Start()
    {
        _farmObjects = _farmObjects.OrderBy(farmObject => farmObject.Structure.LevelToBuild).ToList();
        CreateButtonPool();
        _window = gameObject;
        _window.SetActive(false);
    }

    private void CreateButtonPool()
    {
        foreach (var farmObject in _farmObjects)
        {
            CreateButton(_upgradeButtonTemplate, farmObject);
            CreateButton(_buyButtonTemplate, farmObject);
        }
    }

    private void CreateButton(GameObject buttonTemplate, AbstractFarmObject farmObject)
    {
        var button = Instantiate(buttonTemplate, _container).GetComponent<ImprovementButton>();
        button.Init(farmObject);
        _buttonPool.Add(button);
        button.gameObject.SetActive(false);
    }

    public void OnWindow()
    {
        if (!_window.activeSelf)
            InputUI.Instance.Action += ShowWindow;
        else
            InputUI.Instance.Action -= ShowWindow;
    }

    private void ShowWindow()
    {
        _window.SetActive(true);
        Render();
    }

    public void Render()
    {
        foreach (var button in _buttonPool)
        {
            if (!button.FarmObject.Structure.IsBuilt)
                button.gameObject.SetActive(button.ButtonName.Contains("Buy"));
            else if (button.FarmObject.Level.CurrentLevel < button.FarmObject.Level.MaxLevel)
                button.gameObject.SetActive(button.ButtonName.Contains("Upgrade"));
            else
                button.gameObject.SetActive(false);

            button.Button.onClick.AddListener(Render);
        }
    }
}
