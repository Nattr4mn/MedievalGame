using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Outline>().enabled = true;
        UIManager.Instance.ActionEvent += ReplenishingThirst;
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Outline>().enabled = false;
        UIManager.Instance.ActionEvent -= ReplenishingThirst;
    }

    public void ReplenishingThirst()
    {
        //Player.Instance.Animator.SetBool("isRunning", false);
        //Player.Instance.Animator.SetTrigger("pickup");
        //Player.Instance.Characteristics.ReplenishingThirst(2f);
    }
}
