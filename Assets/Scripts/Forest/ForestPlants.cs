using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Outline))]
public class ForestPlants : ActivatableObject
{
    [SerializeField] private Item _item;
    [Range(1, 3)][SerializeField] private float minimumNumberOfDrops = 1f;
    [Range(3, 5)] [SerializeField] private float maximumNumberOfDrops = 3f;

    public void ActivationAction()
    {
        var harvest = (int)Random.Range(minimumNumberOfDrops, maximumNumberOfDrops);
        var exp = harvest / (2 + Player.Characteristics.Level.Value);
        Player.Input.PlayerAction -= ActivationAction;

        Player.Input.Collecting();
        Player.Characteristics.AddExperience(exp);
        Player.Reward.ShowRewards(_item.UiIcon, harvest, exp);
        _item.Count += harvest;
        Destroy(gameObject);
    }
}
