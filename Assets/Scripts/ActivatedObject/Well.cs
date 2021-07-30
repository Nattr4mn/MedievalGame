using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Outline>().enabled = true;
        //GameUI.Instance.ActionEvent += other.GetComponent<PlayerItems>().FillBucket;
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Outline>().enabled = false;
        //GameUI.Instance.ActionEvent -= other.GetComponent<PlayerItems>().FillBucket;
    }
}
