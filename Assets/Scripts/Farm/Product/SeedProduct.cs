using UnityEngine;

[CreateAssetMenu(menuName = "Product/Seed Product")]
public class SeedProduct : ScriptableObject, IFarmProduct
{
    public string ProductName => _cropName;
    public int ProductPrice => _price;
    public DerivedProduct DerivedProduct => _crop;
    public Sprite UIIcon => _uiIcon; 
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value > _maxQuantity)
                _quantity = _maxQuantity;
            else
                _quantity = value;
        }
    }
    public int MaxQuantity => _maxQuantity;

    [SerializeField] private string _cropName;
    [SerializeField] private int _price;
    [SerializeField] private int _quantity;
    [SerializeField] private int _maxQuantity;
    [SerializeField] private DerivedProduct _crop;
    [SerializeField] private Sprite _uiIcon;
}
