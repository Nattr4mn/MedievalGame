using System.Collections;
using UnityEngine;

public class GardenController : MonoBehaviour
{
    [SerializeField] private ResourcePanel resourcePanel;
    [SerializeField] private float growthTime = 10f;
    [SerializeField] private float irrigationTime = 5f;
    private bool can—ollect = false;
    private bool isSown = false;
    private bool isProcessBarVisible = false;
    private float irrigationLevel = 0;
    private float growthRate = 0;
    private string currentFarmCrop;

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
        if(other.name == Player.Instance.name)
        {
            isProcessBarVisible = true;
            ProcessGrowthBar(true);
            UIManager.Instance.SliderSetPosition(gameObject.transform.position);
            if (can—ollect)
                UIManager.Instance.actionButtonEvent += Gathering;
            
            if(!isSown)
                UIManager.Instance.actionButtonEvent += SeedsPanel;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == Player.Instance.name)
        {
            isProcessBarVisible = false;
            ProcessGrowthBar(false);
            if (can—ollect)
                UIManager.Instance.actionButtonEvent -= Gathering;

            if (!isSown)
                UIManager.Instance.actionButtonEvent -= SeedsPanel;
        }
    }

    private void SeedsPanel()
    {
        UIManager.Instance.actionButtonEvent += Planting;
        resourcePanel.Init(PlayerResources.Instance.SeedsList);
        resourcePanel.gameObject.SetActive(true);
        UIManager.Instance.ActionButton.gameObject.SetActive(false);
    }

    private void ProcessGrowthBar(bool state)
    {
        UIManager.Instance.growthRateSlider.gameObject.SetActive(state); //fix
        UIManager.Instance.irrigationLevelSlider.gameObject.SetActive(state); //fix
    }

    public void Gathering()
    {
        StartCoroutine(Processing());
        Player.Instance.isWorking = true;
        transform.Find("Crops").transform.Find(currentFarmCrop).gameObject.SetActive(false);
        irrigationLevel = 0;
        growthRate = 0;
        can—ollect = false;
        isSown = false;
        PlayerResources.Instance.ReplenishStocks(currentFarmCrop, Random.Range(5, 10));
        Player.Instance.Animator.SetBool("isRunning", false);
        Player.Instance.Animator.SetTrigger("gathering");
        UIManager.Instance.actionButtonEvent -= Gathering;
    }


    public void Planting()
    {
        currentFarmCrop = PlayerResources.Instance.currentFarmingCrop;
        UIManager.Instance.actionButtonEvent -= SeedsPanel;
        isSown = true;
        UIManager.Instance.ActionButton.gameObject.SetActive(true);
        Player.Instance.Animator.SetBool("isRunning", false);
        Player.Instance.Animator.SetTrigger("gathering");
        StartCoroutine(ProcessOfGrowth());
        UIManager.Instance.actionButtonEvent -= Planting;
    }

    private IEnumerator ProcessOfGrowth()
    {

        StartCoroutine(Processing());
        Player.Instance.isWorking = true;
        irrigationLevel = 1;
        growthRate = 0;
        transform.Find("Crops").transform.Find(currentFarmCrop).gameObject.SetActive(true);

        while (irrigationLevel != 0 && growthRate != 1)
        {
            irrigationLevel -= 1 /(irrigationTime * 1f);
            growthRate += 1 / (growthTime * 1f);
            yield return new WaitForSeconds(1f);
        }
        can—ollect = true;
    }

    private IEnumerator Processing()
    {
        yield return new WaitForSeconds(3f);
        Player.Instance.isWorking = false;
    }
}
