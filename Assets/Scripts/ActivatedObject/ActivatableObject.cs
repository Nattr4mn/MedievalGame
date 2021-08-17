using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class ActivatableObject : MonoBehaviour
{
    public Player Player;
    public UnityEvent Events;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = true;
            Player = other.gameObject.GetComponent<Player>();
            Events?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = false;
            Player = null;
            Events?.Invoke();
        }
    }
}
