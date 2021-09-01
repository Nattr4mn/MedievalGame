using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmData : AbstractSavedObject<AbstractFarmObject>
{
    private string _saveFileName = "";
    public Data SavedData = new Data();
    private AbstractFarmObject _savedObject;

    public override void Load(AbstractFarmObject savedObject)
    {
        _saveFileName = savedObject.FarmObjectName;
        _savedObject = savedObject;
        Save<Data> saveData = new Save<Data>(_saveFileName);
        SavedData = saveData.LoadData();

        if (SavedData != null)
        {
            DateTime exitTime = DateTime.Parse(SavedData.SaveTime);
            TimeSpan timeDifference = DateTime.Now - exitTime;
            int secondsPassed = (int)timeDifference.TotalSeconds;

            if(SavedData.IsBuilt && SavedData.Occupied)
            {
                if (!SavedData.CanCollect)
                {
                    CalculatingTime(secondsPassed);
                }
                else
                {
                    SpoilTime(SavedData.SpoilTime + secondsPassed, savedObject.ProductionTime);
                }
            }
            else
            {
                Under—onstruction(secondsPassed, savedObject.Structure.TimeToBuild);
            }

        }
    }

    public override void Save()
    {
        SavedData.SaveTime                  = DateTime.Now.ToString();
        SavedData.Occupied                  = _savedObject.Occupied;
        SavedData.WaterLevel                = _savedObject.WaterLevel;
        SavedData.Spoil                     = _savedObject.Spoil;
        SavedData.SpoilTime                 = _savedObject.SpoilTime;
        SavedData.ProductionStage           = _savedObject.—urrentContent.ProductionStage;
        SavedData.CanCollect                = _savedObject.—urrentContent.CanCollect;
        SavedData.ProductName               = _savedObject.—urrentContent.Name;
        SavedData.IsBuilt                   = _savedObject.Structure.IsBuilt;
        SavedData.CurrentConstructionTime   = _savedObject.Structure.CurrentConstructionTime;
        SavedData.Under—onstruction         = _savedObject.Structure.Under—onstruction;
        SavedData.GardenLevel               = _savedObject.Level.CurrentLevel;
    }

    private void CalculatingTime(float secondsPassed)
    {
        int timeProductionLeft = (int)((_savedObject.ProductionTime - (_savedObject.ProductionTime * _savedObject.—urrentContent.ProductionStage)));
        int timeWaterLeft = (int)(((_savedObject.ProductionTime / 3f) - ((_savedObject.ProductionTime / 3f) * _savedObject.WaterLevel)));

        if (timeWaterLeft >= timeProductionLeft)
        {
            if (secondsPassed >= timeProductionLeft)
            {
                SavedData.ProductionStage = 1f;
                SavedData.CanCollect = true;
                SavedData.WaterLevel -= timeProductionLeft * (1f / (_savedObject.ProductionTime / 3f));
                SpoilTime(secondsPassed - timeProductionLeft, _savedObject.ProductionTime);
            }
            else
            {
                CalculatingStage(secondsPassed);
            }
        }
        else
        {
            if (secondsPassed >= timeWaterLeft)
            {
                SavedData.WaterLevel = 0f;
                SavedData.ProductionStage += timeWaterLeft * (1f / _savedObject.ProductionTime);
                SpoilTime(secondsPassed - timeWaterLeft, _savedObject.ProductionTime);
            }
            else
            {
                CalculatingStage(secondsPassed);
            }
        }
    }

    private void CalculatingStage(float secondsPassed)
    {
        SavedData.WaterLevel -= secondsPassed * (1f / (_savedObject.ProductionTime / 3f));
        SavedData.ProductionStage += secondsPassed * (1f / _savedObject.ProductionTime);
    }

    private void Under—onstruction(float secondsPassed, float timeToBuild)
    {
        if (SavedData.Under—onstruction)
        {
            float currentConstructionTime = SavedData.CurrentConstructionTime + secondsPassed;
            if (currentConstructionTime > timeToBuild)
            {
                SavedData.CurrentConstructionTime = 0f;
                SavedData.IsBuilt = true;
                SavedData.Under—onstruction = false;
            }
            else
            {
                SavedData.CurrentConstructionTime = currentConstructionTime;
            }
        }
    }

    private void SpoilTime(float secondsPassed, float productionTime)
    {
        int spoilTime = (int)(productionTime / 4f);
        if (secondsPassed >= spoilTime)
        {
            SavedData.Occupied = false;
            SavedData.ProductionStage = 0f;
            SavedData.CanCollect = false;
            SavedData.WaterLevel = 0f;
            SavedData.Spoil = false;
            SavedData.SpoilTime = 0f;
        }
        else
        {
            SavedData.Spoil = true;
            SavedData.SpoilTime = spoilTime - secondsPassed;
        }
    }
}

[Serializable]
public class Data
{
    public string   SaveTime;
    public bool     Occupied;
    public float    WaterLevel;
    public bool     Spoil;
    public float    SpoilTime;
    public float    ProductionStage;
    public bool     CanCollect;
    public string   ProductName;
    public bool     IsBuilt;
    public bool     Under—onstruction;
    public float    CurrentConstructionTime;
    public int      GardenLevel;
}