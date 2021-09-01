using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSavedObject<T> : MonoBehaviour
{
    public abstract void Save();
    public abstract void Load(T savedObject);

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        Save();
    }
#endif
    private void OnApplicationQuit()
    {
        Save();
    }
}
