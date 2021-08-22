using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _playerSpeed;
    private bool isLocked = false;
    private Movement _playerMovement;

    private void Awake()
    {
        _playerMovement = _playerObject.AddComponent<Movement>();
        _playerMovement.Init(_playerSpeed, _rigidbody);
    }

    private void FixedUpdate()
    {
        if (InputUI.Instance.Joystick.Vertical != 0 && !isLocked)
        {
            _animator.SetBool("isRunning", true);
            _playerMovement.Move();

            if (InputUI.Instance.Joystick.Vertical > 0)
                _playerMovement.Rotate(90f * InputUI.Instance.Joystick.Horizontal);
            else if (InputUI.Instance.Joystick.Vertical < 0)
                _playerMovement.Rotate(180f + (-90f) * InputUI.Instance.Joystick.Horizontal);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    public void Collecting()
    {
        isLocked = true;
        InputUI.Instance.Action -= Collecting;
        StartCoroutine(CollectingCoroutine("gathering"));
    }

    public void PickUp()
    {
        isLocked = true;
        InputUI.Instance.Action -= PickUp;
        StartCoroutine(CollectingCoroutine("pickup"));
    }

    private IEnumerator CollectingCoroutine(string animationName)
    {
        _animator.SetTrigger(animationName);
        yield return new WaitForSeconds(3f);
        isLocked = false;
    }
}
