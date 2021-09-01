using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFarmContent : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract IFarmProduct Product { get; }
    public float ProductionStage => _productionStage;
    public bool CanCollect => _canCollect;

    private float _productionStage;
    private bool _canCollect;

    public void Init(float productionStage, bool canCollect)
    {
        _productionStage = productionStage;
        _canCollect = canCollect;
    }

    public void Growth(float value)
    {
        _productionStage += value;
        if (_productionStage >= 1f)
            _canCollect = true;
    }

    public void Execute()
    {
        _productionStage = 0f;
        _canCollect = false;
        gameObject.SetActive(false);
    }
}
