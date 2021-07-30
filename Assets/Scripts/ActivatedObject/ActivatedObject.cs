using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public abstract class ActivatedObject : MonoBehaviour
{
    public Player Player => _player;

    [SerializeField] private UnityEvent<bool> Event;
    private Player _player;

    public abstract void ActivationAction();

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().enabled = true;
            _player = other.gameObject.GetComponent<Player>();
            Event?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.Input.ActionEvent -= ActivationAction;
            gameObject.GetComponent<Outline>().enabled = false;
            Event?.Invoke(false);
        }
    }
}
