using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shed : MonoBehaviour
{
    [SerializeField] private ResourcePanel resourcePanel;
    private GameObject _player;
    private void OnTriggerEnter(Collider other)
    {
        _player = other.gameObject;
        UIManager.Instance.ActionEvent += ResourcePanel;
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.Instance.ActionEvent -= ResourcePanel;
    }

    public void ResourcePanel()
    {
        //resourcePanel.Init(Player.Instance.Resources.ItemList);
        StartCoroutine(PlayingAnimation());
        UIManager.Instance.ActionButton.gameObject.SetActive(true);
        resourcePanel.gameObject.SetActive(true);
    }

    private IEnumerator PlayingAnimation()
    {
        _player.GetComponent<Player>().isWorking = true;
        _player.GetComponentInChildren<Animator>().SetBool("isRunning", false);
        _player.GetComponentInChildren<Animator>().SetTrigger("pickup");
        yield return new WaitForSeconds(1f);
        _player.GetComponent<Player>().isWorking = false;
    }
}
