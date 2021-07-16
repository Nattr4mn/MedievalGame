using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shed : MonoBehaviour
{
    [SerializeField] private ResourcePanel resourcePanel;
    private void OnTriggerEnter(Collider other)
    {
        UIManager.Instance.actionButtonEvent += ResourcePanel;
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.Instance.actionButtonEvent -= ResourcePanel;
    }

    public void ResourcePanel()
    {
        resourcePanel.Init(PlayerResources.Instance.ItemList);
        StartCoroutine(PlayingAnimation());
        UIManager.Instance.ActionButton.gameObject.SetActive(true);
        resourcePanel.gameObject.SetActive(true);
    }

    private IEnumerator PlayingAnimation()
    {
        Player.Instance.isWorking = true;
        Player.Instance.Animator.SetBool("isRunning", false);
        Player.Instance.Animator.SetTrigger("pickup");
        yield return new WaitForSeconds(1f);
        Player.Instance.isWorking = false;
    }
}
