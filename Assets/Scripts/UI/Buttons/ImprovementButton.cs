using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImprovementButton : MonoBehaviour
{
    public Button Button => _button;
    public string ButtonName => _buttonName;
    public AbstractFarmObject FarmObject => _farmObject;
    [SerializeField] private string _buttonName;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _buttonText;
    private AbstractFarmObject _farmObject = null;

    public void Init(AbstractFarmObject farmObject)
    {
        _buttonText.text = farmObject.name;
        _farmObject = farmObject;
        Improvement();
    }

    public void Improvement()
    {
        //if (_farmObject.Structure.IsBuilt && _farmObject.Level.CurrentLevel < _farmObject.Level.MaxLevel)
        //    _button.onClick.AddListener(_farmObject.Level.LevelUp);
        //else
        //    _button.onClick.AddListener(_farmObject.Structure.Build);
    }
}
