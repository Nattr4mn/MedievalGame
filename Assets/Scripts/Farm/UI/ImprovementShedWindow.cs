using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovementShedWindow : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _buildButtonTemplate;
    [SerializeField] private GameObject _upgradeButtonTemplate;
    [SerializeField] private ImprovementShed _improvementShed;
    private List<AbstractFarmObject> _farmObject = new List<AbstractFarmObject>();

    private void Start()
    {
        _farmObject.Add((AbstractFarmObject)_improvementShed.GetObjects());
        print(_farmObject);
    }

    public void ShowWindow()
    {
    }

    private void Render()
    {

    }
}
