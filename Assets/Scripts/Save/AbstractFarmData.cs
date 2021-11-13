//using System;

//public class AbstractFarmData : AbstractSavedObject<AbstractFarmObject>
//{
//    [Serializable]
//    public class Data
//    {
//        public string SaveTime;
//        public bool Occupied;
//        public float WaterLevel;
//        public float FoodLevel;
//        public bool IsSpoil;
//        public float SpoilTime;
//        public float ProductionStage;
//        public bool CanCollect;
//        public string ProductName;
//        public bool IsBuilt;
//        public bool Under—onstruction;
//        public float CurrentConstructionTime;
//        public int GardenLevel;
//    }

//    private string _saveFileName = "";
//    public Data SavedData = new Data();
//    private AbstractFarmObject _farmObject;

//    public override void Load(AbstractFarmObject savedObject)
//    {
//        _saveFileName = savedObject.FarmObjectName;
//        _farmObject = savedObject;
//        Save<Data> saveData = new Save<Data>(_saveFileName);
//        SavedData = saveData.LoadData();

//        if (SavedData != null)
//        {
//            DateTime exitTime = DateTime.Parse(SavedData.SaveTime);
//            TimeSpan timeDifference = DateTime.Now - exitTime;
//            int secondsPassed = (int)timeDifference.TotalSeconds;

//            if (SavedData.IsBuilt && SavedData.Occupied)
//            {
//                if (!SavedData.CanCollect)
//                {
//                    CalculatingTime(secondsPassed);
//                }
//                else
//                {
//                    SpoilTime(SavedData.SpoilTime + secondsPassed, savedObject.ProductionTime);
//                }
//            }
//            else
//            {
//                Under—onstruction(secondsPassed, savedObject.Structure.TimeToBuild);
//            }

//        }
//    }

//    public override void Save()
//    {
//        if (_farmObject.Structure.Under—onstruction || _farmObject.Structure.IsBuilt)
//        {
//            Save<Data> saveData = new Save<Data>(_saveFileName);
//            SavedData.SaveTime = DateTime.Now.ToString();
//            SavedData.Occupied = _farmObject.Occupied;
//            SavedData.WaterLevel = _farmObject.WaterLevel;
//            SavedData.IsSpoil = _farmObject.Spoiling.IsSpoil;
//            SavedData.SpoilTime = _farmObject.Spoiling.SpoilTime;
//            SavedData.ProductionStage = _farmObject.—urrentContent.ProductionStage;
//            SavedData.CanCollect = _farmObject.—urrentContent.CanCollect;
//            SavedData.ProductName = _farmObject.—urrentContent.Name;
//            SavedData.IsBuilt = _farmObject.Structure.IsBuilt;
//            SavedData.CurrentConstructionTime = _farmObject.Structure.CurrentConstructionTime;
//            SavedData.Under—onstruction = _farmObject.Structure.Under—onstruction;
//            SavedData.GardenLevel = _farmObject.Level.CurrentLevel;
//            saveData.SaveData(SavedData);
//        }
//    }

//    private void CalculatingTime(float secondsPassed)
//    {
//        int timeProductionLeft = (int)((_farmObject.ProductionTime - (_farmObject.ProductionTime * _farmObject.—urrentContent.ProductionStage)));
//        int timeWaterLeft = (int)(((_farmObject.ProductionTime / 3f) - ((_farmObject.ProductionTime / 3f) * _farmObject.WaterLevel)));

//        if (timeWaterLeft >= timeProductionLeft)
//        {
//            if (secondsPassed >= timeProductionLeft)
//            {
//                SavedData.ProductionStage = 1f;
//                SavedData.CanCollect = true;
//                SavedData.WaterLevel -= timeProductionLeft * (1f / (_farmObject.ProductionTime / 3f));
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
//                SavedData.WaterLevel = 0f;
//                SavedData.ProductionStage += timeWaterLeft * (1f / _farmObject.ProductionTime);
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
//        SavedData.WaterLevel -= secondsPassed * (1f / (_farmObject.ProductionTime / 3f));
//        SavedData.ProductionStage += secondsPassed * (1f / _farmObject.ProductionTime);
//    }

//    private void Under—onstruction(float secondsPassed, float timeToBuild)
//    {
//        if (SavedData.Under—onstruction)
//        {
//            float currentConstructionTime = SavedData.CurrentConstructionTime + secondsPassed;
//            if (currentConstructionTime > timeToBuild)
//            {
//                SavedData.CurrentConstructionTime = 0f;
//                SavedData.IsBuilt = true;
//                SavedData.Under—onstruction = false;
//            }
//            else
//            {
//                SavedData.CurrentConstructionTime = currentConstructionTime;
//            }
//        }
//    }

//    private void SpoilTime(float secondsPassed, float productionTime)
//    {
//        int spoilTime = (int)(productionTime / 4f);
//        if (secondsPassed >= spoilTime)
//        {
//            SavedData.Occupied = false;
//            SavedData.ProductionStage = 0f;
//            SavedData.CanCollect = false;
//            SavedData.WaterLevel = 0f;
//            SavedData.IsSpoil = false;
//            SavedData.SpoilTime = 0f;
//        }
//        else
//        {
//            SavedData.IsSpoil = true;
//            SavedData.SpoilTime = spoilTime - secondsPassed;
//        }
//    }
//}
