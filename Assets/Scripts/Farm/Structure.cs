using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Structure : MonoBehaviour
{
    public UnityEvent Events;
    public bool IsBuilt => _isBuilt;
    public int LevelToBuild => _levelToBuild;
    [SerializeField] private bool _isBuilt = false;
    [SerializeField] private float _price = 0f;
    [SerializeField] private int _levelToBuild = 0;
    [SerializeField] private float _timeToBuild = 0f;
    private float _currentConstructionTime = 0f;
    private GameObject _structure;
    private Player _player;

    public void Init(Player player)
    {
        _player = player;
        _structure = gameObject;
        _structure.SetActive(_isBuilt);
    }

    public void Build()
    {
        if (_player?.Items.Gold.Value >= _price && _player?.Characteristics.Level.Value >= _levelToBuild && !_isBuilt)
        {
            _structure.SetActive(true);
            _isBuilt = true;
        }
        //StartCoroutine(Building());
    }

    private IEnumerator Building()
    {
        while(_currentConstructionTime < _timeToBuild)
        {
            yield return new WaitForSeconds(0.1f);
            _currentConstructionTime += _timeToBuild / 600;
            Events?.Invoke();
        }
        _isBuilt = true;
        _structure.SetActive(true);
        _currentConstructionTime = 0f;
    }
}
