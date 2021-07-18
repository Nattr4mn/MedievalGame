using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        UIManager.Instance.actionButtonEvent += ReplenishingThirst;
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.Instance.actionButtonEvent -= ReplenishingThirst;
    }

    public void ReplenishingThirst()
    {
        Player.Instance.Animator.SetBool("isRunning", false);
        Player.Instance.Animator.SetTrigger("pickup");
        Player.Instance.Characteristics.ReplenishingThirst(2f);
    }
}
