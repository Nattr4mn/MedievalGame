using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveTime : MonoBehaviour
{
    [SerializeField] private TimeManager _timeManager;
    private string path;


    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if(File.Exists(path))
        {
            _timeManager = JsonUtility.FromJson<TimeManager>(File.ReadAllText(path));
            print("Текущее время: " + _timeManager.CurrentTime);
        }
    }

#if UNITY_ANDROID  && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if(pause)
            File.WriteAllText(path, JsonUtility.ToJson(_timeManager));
    }
#endif
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(_timeManager));
    }
}
