using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmObjectLevel : MonoBehaviour
{
    public int MaxLevel => _maxLevel;
    public int CurrentLevel => _currentLevel;

    [SerializeField] private int _maxLevel = 5;
    private int _currentLevel = 0;

    public void LevelUp()
    {
        print(_currentLevel);
        if (_currentLevel < _maxLevel)
            _currentLevel++;
    }
}
