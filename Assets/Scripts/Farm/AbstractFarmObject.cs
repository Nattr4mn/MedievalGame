using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FarmObjectLevel))]
[RequireComponent(typeof(Structure))]
[RequireComponent(typeof(InteractiveObject))]
[RequireComponent(typeof(Spoiling))]
public abstract class AbstractFarmObject : MonoBehaviour
{
    public string FarmObjectName => _gardenName;
    public float WaterLevel => _waterLevel;
    public float ProductionTime => _productionTime;
    public bool Occupied => _occupied;
    public AbstractFarmContent ÑurrentContent => _currentContent;
    public List<AbstractFarmContent> ContentList => _contentList;
    public FarmObjectLevel Level { get; private set; }
    public Structure Structure { get; private set; }
    public InteractiveObject InteractiveObject { get; private set; }
    public Spoiling Spoiling{ get; private set; }

    private protected AbstractFarmContent _currentContent;
    private protected float _waterLevel;
    private protected bool _occupied;

    [SerializeField] private string _gardenName;
    [SerializeField] private float _productionTime;
    [SerializeField] private List<AbstractFarmContent> _contentList;

    public abstract void Init(Data farmData);
    public abstract bool TryFill(string objectName, float water);
    public abstract Tuple<IFarmProduct, int> Collecting(int playerLevel, int playerLuck, float playerEnergy, out int playerExperience);
    public abstract void StartProcessOfGrowth();

    public virtual void Clear()
    {
        _waterLevel = 0f;
        _occupied = false;
        _currentContent.Execute();
        _currentContent = null;
        InteractiveObject.Events?.Invoke(InteractiveObject);
    }

    public void AddWater(float value)
    {
        if (value > 0f)
            _waterLevel += value;
        if (_waterLevel > 1f)
            _waterLevel = 1f;
    }

    private void Awake()
    {
        Level = GetComponent<FarmObjectLevel>();
        Structure = GetComponent<Structure>();
        InteractiveObject = GetComponent<InteractiveObject>();
        Spoiling = GetComponent<Spoiling>();
        Spoiling.Init(this, _productionTime / 4, null);
        ContentList.ForEach(content => content.gameObject.SetActive(false));
    }
}
