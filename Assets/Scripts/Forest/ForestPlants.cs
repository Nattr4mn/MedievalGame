using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Outline))]
public class ForestPlants : ActivatedObject
{
    [SerializeField] private Item _item;
    [Range(1, 3)][SerializeField] private float minimumNumberOfDrops = 1f;
    [Range(3, 5)] [SerializeField] private float maximumNumberOfDrops = 3f;

    public override void ActivationAction()
    {
        Player.Collecting();
        _item.Count += (int)Random.Range(minimumNumberOfDrops, maximumNumberOfDrops);
        Player.Input.ActionEvent -= ActivationAction;
        Destroy(gameObject);
    }
}
