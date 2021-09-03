using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public int Food => _food;
    public int Gold => _gold;
    public float Bucket => _bucket;

    [SerializeField] private int _food;
    [SerializeField] private int _gold;
    [SerializeField] private float _bucket;

    public void FillBucket()
    {
        _bucket = Random.Range(0.5f, 1f);
    }    
    
    public bool TryEmptyTheBucket()
    {
        if (_bucket > 0)
        {
            _bucket = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}

