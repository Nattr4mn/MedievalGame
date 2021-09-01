using UnityEngine;

public interface IFarmProduct
{
    string ProductName { get; }
    int ProductPrice { get; }
    DerivedProduct DerivedProduct { get;}
    Sprite UIIcon { get; }
}
