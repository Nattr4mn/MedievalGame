using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSeelctionWindow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private List<Animal> _animalList;
    [SerializeField] private Transform _container;
    [SerializeField] private SeedButton _buttonTemplate;
    [SerializeField] private GardensUI _gardensManager;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
