using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement Movement => _playerMovement;
    public PlayerCharacteristics Characteristics => _playerCharacteristics;
    public PlayerResources Resources => _playerResources;
    public Animator Animator => _animator;
    public bool isWorking = false;

    [SerializeField] private GameObject _playerObject;
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private PlayerCharacteristics _playerCharacteristics;
    [SerializeField] private PlayerResources _playerResources;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = _playerObject.AddComponent<PlayerMovement>();
        _playerMovement.Init(_playerSpeed, _playerRB);
    }

    private void FixedUpdate()
    {
        if(!isWorking)
        {
            if(UIManager.Instance.Vertical != 0)
            {
                _playerMovement.PlayerMove();


                _animator.SetBool("isRunning", true);
                if (UIManager.Instance.Vertical > 0)
                    _playerMovement.PlayerRotate(90f * UIManager.Instance.Horizontal);
                else if (UIManager.Instance.Vertical < 0)
                    _playerMovement.PlayerRotate(180f + (-90f) * UIManager.Instance.Horizontal);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }  
    }
}
