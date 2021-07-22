using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class Shed : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> ShedEvents;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Outline>().enabled = true;
        ShedEvents?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Outline>().enabled = false;
        ShedEvents?.Invoke(false);
    }
}
