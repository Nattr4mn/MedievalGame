using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Loader<Player>
{
    public List<string> AnimationParameterList => animationParameterList;
    public Animator Animator => _animator;
    public bool isWorking = false;

    [SerializeField] private PlayerMoveController playerMoveController;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<string> animationParameterList;

    private Rigidbody _playerRB;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody>();
        playerMoveController.Init(_playerSpeed, _playerRB);
    }


    private void FixedUpdate()
    {
        if(!isWorking)
        {
            if(UIManager.Instance.Vertical != 0)
            {
                playerMoveController.PlayerMove();


                _animator.SetBool("isRunning", true);
                if (UIManager.Instance.Vertical > 0)
                    playerMoveController.PlayerRotate(90f * UIManager.Instance.Horizontal);
                else if (UIManager.Instance.Vertical < 0)
                    playerMoveController.PlayerRotate(180f + (-90f) * UIManager.Instance.Horizontal);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }  
    }
}
