using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenContent : AbstractFarmContent
{
    public override string Name => _name;
    public override IFarmProduct Product => _seedProduct;

    private string _name;
    [SerializeField] private SeedProduct _seedProduct;

    private void Start()
    {
        _name = _seedProduct.DerivedProduct.Name;
    }
}
