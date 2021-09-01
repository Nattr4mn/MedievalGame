using UnityEngine;

[CreateAssetMenu(menuName = "Product/Derived Product")]
public class DerivedProduct : ScriptableObject
{
    public string Name => _name;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value >= _maxQuantity)
                _quantity = 0;
            else if (_quantity + value > _maxQuantity)
                _quantity = _maxQuantity;
            else
                _quantity += value;
        }
    }
    public int MaxQuantity => _maxQuantity;
    public int Price => _price;
    public Sprite UIIcon => _uiIcon;

    [SerializeField] private string _name;
    [SerializeField] private int _quantity;
    [SerializeField] private int _maxQuantity;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _uiIcon;
}
