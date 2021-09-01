using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerLevel : MonoBehaviour
{
    public int Level => _level;
    public float Experience => _experience;

    [SerializeField] private int _level;
    [SerializeField] private int _maxLevel;
    private float _experience = 0f;

    public void AddExperience(float experience)
    {
        _experience += experience;
        if (_experience >= 10 + (1 * _level))
        {
            if (_level != _maxLevel)
            {
                _experience -= (10 + (1 * _level));
                _level++;
            }
        }
    }
}
