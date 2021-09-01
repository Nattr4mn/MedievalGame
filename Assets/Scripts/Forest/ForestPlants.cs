using System;
using UnityEngine;


[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(InteractiveObject))]
public class ForestPlants : MonoBehaviour
{
    [SerializeField] private DerivedProduct _product;
    [Range(1, 3)][SerializeField] private float minimumNumberOfDrops = 1f;
    [Range(3, 5)] [SerializeField] private float maximumNumberOfDrops = 3f;
    private InteractiveObject _activatableObject;

    private void Start()
    {
        _activatableObject = GetComponent<InteractiveObject>();
        //_activatableObject.Events.AddListener(OnAction);
    }

    public void OnAction()
    {
        if (_activatableObject.Player != null)
            InputUI.Instance.Action += PlantCollect;
        else
            InputUI.Instance.Action -= PlantCollect;
    }

    private void PlantCollect()
    {
        var harvest = (int)UnityEngine.Random.Range(minimumNumberOfDrops, maximumNumberOfDrops);
        //var exp = harvest / (2 + _activatableObject.Player.Characteristics.Level.Value);
        InputUI.Instance.Action -= PlantCollect;

        _activatableObject.Player.Input.Collecting();
        //RewardForPlant(harvest, exp);
        gameObject.SetActive(false);
    }

    private void RewardForPlant(float harvest, float exp)
    {
        var reward = InputUI.Instance.Reward;
        var harverReward = Tuple.Create(_product.UIIcon, harvest);
        var expReward = Tuple.Create(reward.ExpIcon, exp);

        reward.ShowRewards(harverReward, expReward);
        //_activatableObject.Player.Characteristics.AddExperience(exp);
        _product.Quantity += (int)harvest;
    }
}
