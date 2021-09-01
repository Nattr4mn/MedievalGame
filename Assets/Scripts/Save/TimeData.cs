using System;
using UnityEngine;

public class TimeData : AbstractSavedObject<TimeController>
{
    [Serializable]
    public class Data
    {
        public string ExitTime;
        public float CurrentTime;
        public Weekday Weekday;
    }

    public Data SavedData = new Data();

    private string _saveFileName = "TimeData";
    private TimeController _timeManager;
    private Save<Data> saveData;

    public override void Save()
    {
        SavedData.ExitTime = DateTime.Now.ToString();
        SavedData.CurrentTime = _timeManager.CurrentTime;
        SavedData.Weekday = _timeManager.Weekday;
        saveData.SaveData(SavedData);
    }

    public override void Load(TimeController timeManager)
    {
        _timeManager = timeManager;
        saveData = new Save<Data>(_saveFileName);
        saveData.LoadData();

        if (saveData.Data != null)
            TimeCalculating();
    }

    private void TimeCalculating()
    {
        DateTime exitTime = DateTime.Parse(saveData.Data.ExitTime);
        TimeSpan deltaTime = DateTime.Now - exitTime;

        float timePassed = saveData.Data.CurrentTime + ((float)(deltaTime.TotalSeconds / _timeManager.FullDay));
        int daysPassed = (int)timePassed;

        SavedData.CurrentTime = timePassed - daysPassed;
        SavedData.Weekday = saveData.Data.Weekday + daysPassed;

        if (SavedData.Weekday > Weekday.Sunday)
            SavedData.Weekday = Weekday.Monday;
    }
}
