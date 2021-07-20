using UnityEngine;

[CreateAssetMenu(menuName = "Characteristic")]
public class Characteristic : ScriptableObject
{
    public string Name => _name;
    public float Value
    {
        get => _value;
        set
        {
            _value = value;
            if (_value > _maxValue)
                _value = _maxValue;

            if (_value < 0)
                _value = 0;
        }
    }
    public float MaxValue => _maxValue;
    public Sprite UiIcon => _uiIcon;


    [SerializeField] private string _name;
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue;
    [SerializeField] private Sprite _uiIcon;
}
