using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FarmObjectLevel))]
[RequireComponent(typeof(Structure))]
[RequireComponent(typeof(InteractiveObject))]
public abstract class AbstractFarmObject : MonoBehaviour
{
    public string FarmObjectName => _gardenName;
    public float WaterLevel => _waterLevel;
    public float ProductionTime => _productionTime;
    public bool Spoil => _spoil;
    public float SpoilTime => _spoilTime;
    public bool Occupied => _occupied;
    public AbstractFarmContent ÑurrentContent => _currentContent;
    public List<AbstractFarmContent> ContentList => _contentList;
    public FarmObjectLevel Level { get; private set; }
    public Structure Structure { get; private set; }
    public InteractiveObject InteractiveObject { get; private set; }
    public delegate bool SpoilOperation();

    private protected GardenContent _currentContent;
    private protected float _waterLevel;
    private protected bool _spoil;
    private protected float _spoilTime;
    private protected bool _occupied;

    [SerializeField] private string _gardenName;
    [SerializeField] private float _productionTime;
    [SerializeField] private List<AbstractFarmContent> _contentList;

    //bool occupied, float waterLevel, float productionStage, bool canCollect, string productName

    public abstract void Init();
    public abstract bool TryFill(string objectName, float water);
    public abstract Tuple<IFarmProduct, int> Collecting(int playerLevel, float playerEnergy, out int playerExperience);
    public abstract void StartProcessOfGrowth();
    public abstract void StartSpoil(SpoilOperation RootingOperation);

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
        ContentList.ForEach(content => content.gameObject.SetActive(false));
    }
}
