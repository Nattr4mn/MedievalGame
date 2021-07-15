using System.Collections;
using UnityEngine;

public class GardenController : MonoBehaviour
{
    [SerializeField] private float growthTime = 10f;
    [SerializeField] private float irrigationTime = 5f;
    private bool can—ollect = false;
    private bool isProcessBarVisible = false;
    private float irrigationLevel = 0;
    private float growthRate = 0;

    private void Update()
    {
        if(isProcessBarVisible)
        {
            UIManager.Instance.SliderSetPosition(transform.position);
            UIManager.Instance.irrigationLevelSlider.value = irrigationLevel;
            UIManager.Instance.growthRateSlider.value = growthRate;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == PlayerController.Instance.name)
        {
            isProcessBarVisible = true;
            ProcessGrowthBar(true);
            UIManager.Instance.SliderSetPosition(gameObject.transform.position);
            ControlManager.Instance.actionButtonEvent += Gathering;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == PlayerController.Instance.name)
        {
            isProcessBarVisible = false;
            ProcessGrowthBar(false);
            ControlManager.Instance.actionButtonEvent -= Gathering;
        }
    }

    private void ProcessGrowthBar(bool state)
    {
        UIManager.Instance.growthRateSlider.gameObject.SetActive(state); //fix
        UIManager.Instance.irrigationLevelSlider.gameObject.SetActive(state); //fix
    }

    private void Gathering()
    {
        irrigationLevel = 1;
        growthRate = 0;
        StartCoroutine(WaitAnimation("gathering"));
        ControlManager.Instance.actionButtonEvent -= Gathering;
        StartCoroutine(ProcessOfGrowth());
        Planting();
    }

    private void Planting()
    {
        transform.Find("Crops").transform.Find("Pumpkin").gameObject.SetActive(true);
    }


    private IEnumerator ProcessOfGrowth()
    {
        while(irrigationLevel != 0 && growthRate != 1)
        {
            irrigationLevel -= 1/(irrigationTime * 60f);
            growthRate += 1 / (growthTime * 60f);
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator WaitAnimation(string animationName)
    {

        PlayerController.Instance.isWorking = true;
        PlayerController.Instance.Animator.SetBool(animationName, true);
        var animatorStateInfo = PlayerController.Instance.Animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(animatorStateInfo.length);
        PlayerController.Instance.Animator.SetBool(animationName, false);
        PlayerController.Instance.isWorking = false;
    }
}
