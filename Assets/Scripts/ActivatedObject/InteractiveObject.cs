using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class InteractiveObject : MonoBehaviour
{
    public UnityEvent<InteractiveObject> Events;
    public Player Player { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = true;
            Player = other.gameObject.GetComponent<Player>();
            Events?.Invoke(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = false;
            Player = null;
            Events?.Invoke(null);
        }
    }
}
