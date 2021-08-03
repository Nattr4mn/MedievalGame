using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Outline>().enabled = true;
        other.GetComponent<Player>().Input.PlayerAction += other.GetComponent<PlayerItems>().FillBucket;
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Outline>().enabled = false;
        other.GetComponent<Player>().Input.PlayerAction -= other.GetComponent<PlayerItems>().FillBucket;
    }
}
