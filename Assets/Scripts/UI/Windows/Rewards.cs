using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewards : MonoBehaviour
{
    public Sprite ExpIcon => _expIcon;
    [SerializeField] private Reward _rewardTemplate;
    [SerializeField] private Transform _rewardContainer;
    [SerializeField] private Sprite _expIcon;
    [SerializeField] private float _timeBtwShow = 1.5f;

    public void ShowRewards(params Tuple<Sprite, float>[] rewards)
    {
        StartCoroutine(RewardsCoroutine(rewards));
    }

    private IEnumerator RewardsCoroutine(params Tuple<Sprite, float>[] rewards)
    {
        foreach(var reward in rewards)
        {
            var rew = Instantiate(_rewardTemplate, _rewardContainer);
            rew.Init(reward.Item2.ToString(), reward.Item1);
            yield return new WaitForSeconds(_timeBtwShow);
        }   
    }
}
