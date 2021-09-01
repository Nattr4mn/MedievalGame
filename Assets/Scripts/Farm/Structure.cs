using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Structure : MonoBehaviour
{
    public UnityEvent Events;
    public bool IsBuilt => _isBuilt;
    public int LevelToBuild => _levelToBuild;
    public float TimeToBuild => _timeToBuild;
    public float CurrentConstructionTime => _currentConstructionTime;
    public bool Under—onstruction => _under—onstruction;

    [SerializeField] private bool _isBuilt = false;
    [SerializeField] private float _price = 0f;
    [SerializeField] private int _levelToBuild = 0;
    [SerializeField] private float _timeToBuild = 0f;
    private bool _under—onstruction = false;
    private float _currentConstructionTime = 0f;
    private GameObject _structure;

    private void Start()
    {
        _structure = gameObject;
        _structure.SetActive(_isBuilt);
    }

    public void Build(int playerGold, int playerLevel)
    {
        if (playerGold >= _price && playerLevel >= _levelToBuild && !_isBuilt)
        {
            _under—onstruction = true;
            StartCoroutine(Building());
        }
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
