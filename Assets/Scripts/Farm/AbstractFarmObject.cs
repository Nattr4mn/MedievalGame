//using System;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(FarmObjectLevel))]
//[RequireComponent(typeof(Structure))]
//[RequireComponent(typeof(InteractiveObject))]
//[RequireComponent(typeof(Spoiling))]
//public abstract class AbstractFarmObject : MonoBehaviour
//{
//    //public bool Occupied { get; private protected set; }
//    //public AbstractFarmContent ÑurrentContent { get; private protected set; }
//    //public string FarmObjectName => _farmObjectName;
//    //public float WaterLevel => _waterLevel;
//    //public float ProductionTime => _productionTime;
//    //public List<AbstractFarmContent> ContentList => _contentList;
//    //public FarmObjectLevel Level { get; private set; }
//    //public Structure Structure { get; private set; }
//    //public InteractiveObject InteractiveObject { get; private set; }
//    //public Spoiling Spoiling{ get; private set; }
//    //public AbstractSavedObject<AbstractFarmObject> FarmData { get; private set; }

//    //[SerializeField] private string _farmObjectName = "";
//    //[SerializeField] private float _productionTime = 0f;
//    //[SerializeField] private List<AbstractFarmContent> _contentList;
//    //private float _waterLevel = 0f;

//    //public abstract void Init();
//    //public abstract bool TryFill(string productName, float water);
//    //public abstract void StartProcessOfGrowth();

//    //public virtual Tuple<IFarmProduct, int> Collecting(int playerLevel, int playerLuck, float playerEnergy, out float playerExperience)
//    //{
//    //    IFarmProduct product = ÑurrentContent.Product;
//    //    var harvest = UnityEngine.Random.Range(5f, 10f) + playerLuck;

//    //    if (playerEnergy <= 0.5f)
//    //    {
//    //        harvest *= (0.5f + playerEnergy);
//    //    }

//    //    product.DerivedProduct.Quantity += (int)harvest;
//    //    playerExperience = (harvest / (2 + playerLevel));
//    //    Clear();
//    //    InteractiveObject.Events?.Invoke(InteractiveObject);
//    //    return new Tuple<IFarmProduct, int>(product, (int)harvest);
//    //}

//    //public virtual void Clear()
//    //{
//    //    _waterLevel = 0f;
//    //    Occupied = false;
//    //    ÑurrentContent.Execute();
//    //    ÑurrentContent = null;
//    //    InteractiveObject.Events?.Invoke(InteractiveObject);
//    //}

//    //public void Fill(float water)
//    //{
//    //    _waterLevel = water;
//    //    Occupied = true;
//    //    ÑurrentContent.gameObject.SetActive(true);
//    //    StartProcessOfGrowth();
//    //    InteractiveObject.Events?.Invoke(InteractiveObject);
//    //}

//    //public void AddWater(float value)
//    //{
//    //    _waterLevel += value;
//    //    if (_waterLevel > 1f)
//    //        _waterLevel = 1f;
//    //}

//    //private void Awake()
//    //{
//    //    Level = GetComponent<FarmObjectLevel>();
//    //    Structure = GetComponent<Structure>();
//    //    InteractiveObject = GetComponent<InteractiveObject>();
//    //    Spoiling = GetComponent<Spoiling>();
//    //    FarmData = GetComponent<AbstractSavedObject<AbstractFarmObject>>();
//    //    ContentList.ForEach(content => content.gameObject.SetActive(false));
//    //    //FarmData.Load(this);
//    //    Init();
//    //}
//}
