using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacteristics))]
[RequireComponent(typeof(PlayerItems))]
public class Player : MonoBehaviour
{
    public PlayerInput Input => _playerInput;
    public PlayerMovement Movement => _playerMovement;
    public PlayerCharacteristics Characteristics => _playerCharacteristics;
    public PlayerItems Items => _playerResources;
    public Animator Animator => _animator;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private PlayerCharacteristics _playerCharacteristics;
    [SerializeField] private PlayerItems _playerResources;
    private PlayerMovement _playerMovement;
    private bool isWorking = false;

    private void Awake()
    {
        _playerMovement = _playerObject.AddComponent<PlayerMovement>();
        _playerMovement.Init(_playerSpeed, _playerRB);
    }

    private void FixedUpdate()
    {
        if(!isWorking)
        {
            if(_playerInput.Vertical != 0)
            {
                _playerMovement.PlayerMove();


                _animator.SetBool("isRunning", true);
                if (_playerInput.Vertical > 0)
                    _playerMovement.PlayerRotate(90f * _playerInput.Horizontal);
                else if (_playerInput.Vertical < 0)
                    _playerMovement.PlayerRotate(180f + (-90f) * _playerInput.Horizontal);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }  
    }

    public void Collecting()
    {
        StartCoroutine(CollectingCoroutine());
    }

    private IEnumerator CollectingCoroutine()
    {
        isWorking = true;
        _animator.SetBool("isRunning", false);
        _animator.SetTrigger("gathering");
        yield return new WaitForSeconds(3f);
        isWorking = false;
    }
}
