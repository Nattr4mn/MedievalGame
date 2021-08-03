using System;
using UnityEngine;


[Serializable]
public class TimeData
{
    public string ExitTime;
    public float CurrentTime;
	public Weekday Weekday;
}

[Serializable]
public class FarmData
{
    public string saveTime;
    public bool isActive;
    public float production;
    public float water;
    public bool occupied;
    public bool canCollect;
}

[Serializable]
public class GardenData : FarmData
{
    public Crop currentCrop;
}