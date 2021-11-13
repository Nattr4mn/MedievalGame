using System.IO;
using UnityEngine;

public class Save<T> : MonoBehaviour
{
    public T Data => _data;
    private T _data;
    private string _saveName;
    private string _path;

    public Save(string saveName)
    {
        _saveName = saveName;

#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, _saveName + ".json");
#else
        _path = Path.Combine(Application.dataPath, _saveName + ".json");
#endif
    }

    public T LoadData()
    {
        if (File.Exists(_path))
        {
            _data = JsonUtility.FromJson<T>(File.ReadAllText(_path));
        }
        return _data;
    }

    public void SaveData(T data)
    {
        File.WriteAllText(_path, JsonUtility.ToJson(data));
    }
}
