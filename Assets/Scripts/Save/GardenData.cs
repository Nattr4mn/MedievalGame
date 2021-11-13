//using System;

//public class GardenData : AbstractSavedObject<AbstractFarmObject>
//{
//    [Serializable]
//    public class Data
//    {
//        public string DataName;
//        public string SaveTime;
//        public bool Occupied;
//        public float WaterLevel;
//        public bool IsSpoil;
//        public float SpoilTime;
//        public string ContentName;
//        public float ProductionStage;
//        public bool CanCollect;
//        public string ProductName;
//        public bool IsBuilt;
//        public bool Under—onstruction;
//        public float CurrentConstructionTime;
//        public int GardenLevel;
//    }

//    private string _saveFileName = "";
//    private Data _savedData;
//    private AbstractFarmObject _farmObject;

//    public override void Load(AbstractFarmObject savedObject)
//    {
//        _savedData = new Data(); ;
//        _saveFileName = savedObject.FarmObjectName;
//        _farmObject = savedObject;
//        Save<Data> saveData = new Save<Data>(_saveFileName);
//        _savedData = saveData.LoadData();

//        if (_savedData != null)
//        {
//            DateTime exitTime = DateTime.Parse(_savedData.SaveTime);
//            TimeSpan timeDifference = DateTime.Now - exitTime;
//            int secondsPassed = (int)timeDifference.TotalSeconds;
//            savedObject.Level.Init(_savedData.GardenLevel);

//            if (_savedData.IsBuilt && _savedData.Occupied)
//            {
//                _farmObject.TryFill(_savedData.ProductName, 0f);

//                if (!_savedData.CanCollect)
//                {
//                    CalculatingTime(secondsPassed);
//                }
//                else
//                {
//                    SpoilTime(_savedData.SpoilTime + secondsPassed, savedObject.ProductionTime);
//                }

//                print(savedObject.—urrentContent);
//                if (savedObject.—urrentContent != null)
//                {
//                    savedObject.AddWater(_savedData.WaterLevel);
//                    savedObject.—urrentContent.Growth(_savedData.ProductionStage);
//                    savedObject.Spoiling.Init(savedObject, savedObject.ProductionTime / 4, _savedData.SpoilTime);
//                    savedObject.StartProcessOfGrowth();
//                }
//            }
//            else
//            {
//                if (_savedData.Under—onstruction)
//                {
//                    Under—onstruction(secondsPassed, savedObject.Structure.TimeToBuild);
//                    savedObject.Structure.Init(_savedData.CurrentConstructionTime);
//                    savedObject.Structure.Build();
//                }
//            }

//        }
//    }

//    public override void Save()
//    {
//        _savedData = new Data();
//        Save<Data> saveData = new Save<Data>(_saveFileName);
//        _savedData.DataName = _farmObject.FarmObjectName;
//        _savedData.SaveTime = DateTime.Now.ToString();
//        _savedData.Occupied = _farmObject.Occupied;
//        _savedData.WaterLevel = _farmObject.WaterLevel;
//        _savedData.IsSpoil = _farmObject.Spoiling.IsSpoil;
//        _savedData.SpoilTime = _farmObject.Spoiling.SpoilTime;
//        _savedData.SpoilTime = _farmObject.Spoiling.SpoilTime;
//        _savedData.ContentName = _farmObject.—urrentContent.Name;
//        _savedData.ProductionStage = _farmObject.—urrentContent.ProductionStage;
//        _savedData.CanCollect = _farmObject.—urrentContent.CanCollect;
//        _savedData.ProductName = _farmObject.—urrentContent.Product.ProductName;
//        _savedData.IsBuilt = _farmObject.Structure.IsBuilt;
//        _savedData.CurrentConstructionTime = _farmObject.Structure.CurrentConstructionTime;
//        _savedData.Under—onstruction = _farmObject.Structure.Under—onstruction;
//        _savedData.GardenLevel = _farmObject.Level.CurrentLevel;
//        saveData.SaveData(_savedData);
//    }

//    private void CalculatingTime(float secondsPassed)
//    {
//        int timeProductionLeft = (int)((_farmObject.ProductionTime - (_farmObject.ProductionTime * _farmObject.—urrentContent.ProductionStage)));
//        int timeWaterLeft = (int)(((_farmObject.ProductionTime / 3f) - ((_farmObject.ProductionTime / 3f) * _farmObject.WaterLevel)));

//        if (timeWaterLeft >= timeProductionLeft)
//        {
//            if (secondsPassed >= timeProductionLeft)
//            {
//                _savedData.ProductionStage = 1f;
//                _savedData.CanCollect = true;
//                _savedData.WaterLevel -= timeProductionLeft * (1f / (_farmObject.ProductionTime / 3f));
//                SpoilTime(secondsPassed - timeProductionLeft, _farmObject.ProductionTime);
//            }
//            else
//            {
//                CalculatingStage(secondsPassed);
//            }
//        }
//        else
//        {
//            if (secondsPassed >= timeWaterLeft)
//            {
//                _savedData.WaterLevel = 0f;
//                _savedData.ProductionStage += timeWaterLeft * (1f / _farmObject.ProductionTime);
//                SpoilTime(secondsPassed - timeWaterLeft, _farmObject.ProductionTime);
//            }
//            else
//            {
//                CalculatingStage(secondsPassed);
//            }
//        }
//    }

//    private void CalculatingStage(float secondsPassed)
//    {
//        _savedData.WaterLevel -= secondsPassed * (1f / (_farmObject.ProductionTime / 3f));
//        _savedData.ProductionStage += secondsPassed * (1f / _farmObject.ProductionTime);
//    }

//    private void Under—onstruction(float secondsPassed, float timeToBuild)
//    {
//        float currentConstructionTime = _savedData.CurrentConstructionTime + secondsPassed;
//        if (currentConstructionTime > timeToBuild)
//        {
//            _savedData.CurrentConstructionTime = 0f;
//            _savedData.IsBuilt = true;
//            _savedData.Under—onstruction = false;
//        }
//        else
//        {
//            _savedData.CurrentConstructionTime = currentConstructionTime;
//        }
//    }

//    private void SpoilTime(float secondsPassed, float productionTime)
//    {
//        int spoilTime = (int)(productionTime / 4f);
//        if (secondsPassed >= spoilTime)
//        {
//            _farmObject.Clear();
//        }
//        else
//        {
//            _savedData.IsSpoil = true;
//            _savedData.SpoilTime = spoilTime - secondsPassed;
//        }
//    }
//}