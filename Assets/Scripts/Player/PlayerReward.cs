using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReward : MonoBehaviour
{
    [SerializeField] private Reward _rewardTemplate;
    [SerializeField] private Transform _rewardContainer;
    [SerializeField] private PlayerCharacteristics _characteristics;
    [SerializeField] private Sprite _expIcon;

    public void ShowRewards(Sprite rewardIcon, float rewardCount, float rewardExpCount)
    {
        StartCoroutine(RewardsCoroutine(rewardIcon, rewardCount, rewardExpCount));
    }

    private IEnumerator RewardsCoroutine(Sprite rewardIcon, float rewardCount, float rewardExpCount)
    {
        var reward = Instantiate(_rewardTemplate, _rewardContainer);
        reward.Init(rewardCount.ToString(), rewardIcon);
        yield return new WaitForSeconds(1.5f);
        if(_characteristics.Level.Value < _characteristics.Level.MaxValue)
        {
            reward = Instantiate(_rewardTemplate, _rewardContainer);
            reward.Init(rewardExpCount.ToString(), _expIcon);
        }    
    }
}
