using UnityEngine;

[CreateAssetMenu(menuName = "Product/Animal Product")]
public class AnimalProduct : ScriptableObject, IFarmProduct
{
    public string ProductName => _animalName;
    public int ProductPrice => _price;
    public DerivedProduct DerivedProduct => _meat;
    public Sprite UIIcon => _uiIcon;
    public DerivedProduct Food—onsumed => _food—onsumed;

    [SerializeField] private string _animalName;
    [SerializeField] private int _price;
    [SerializeField] private DerivedProduct _food—onsumed;
    [SerializeField] private DerivedProduct _meat;
    [SerializeField] private Sprite _uiIcon;
}
