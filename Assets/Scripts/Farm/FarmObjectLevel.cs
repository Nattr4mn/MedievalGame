using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmObjectLevel : MonoBehaviour
{
    public int MaxLevel => _maxLevel;
    public int PlayerLevelToUnlock => _playerLevelToUnlock;
    public int CurrentLevel => _currentLevel;

    [SerializeField] private int _maxLevel = 5;
    [SerializeField] private int _playerLevelToUnlock = 5;
    private int _currentLevel;

    public void LevelUp()
    {
        if (_currentLevel < _maxLevel)
            _currentLevel++;
    }
}
