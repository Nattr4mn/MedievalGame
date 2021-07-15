using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Loader<PlayerController>
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotateMinY;
    [SerializeField] private float rotateMaxY;
    [SerializeField] private PlayerMoveController playerMoveController;
    private Rigidbody _playerRB;
    private Animator _animator;
    public bool isWorking = false;


    public Animator Animator => _animator;

    private void Awake()
    {
        _animator = transform.GetComponentInChildren<Animator>();
        _playerRB = GetComponent<Rigidbody>();
        playerMoveController.Init(playerSpeed, _playerRB, _animator);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            StartCoroutine(WaitAnimation("pickup"));
        }
    }


    private void FixedUpdate()
    {
        if (ControlManager.Instance.Vertical > 0)
        {
            playerMoveController.PlayerMove();
            playerMoveController.PlayerRotate(90f * ControlManager.Instance.Horizontal);
        }
        else if (ControlManager.Instance.Vertical < 0)
        {
            playerMoveController.PlayerMove();
            playerMoveController.PlayerRotate(180f + (-90f) * ControlManager.Instance.Horizontal);
        }
        if(_playerRB.velocity == Vector3.zero && !isWorking )
        {
            _animator.SetBool("run", false);
            _animator.SetBool("idle", true);
        }
        
    }


    private IEnumerator WaitAnimation(string animationName)
    {
        _animator.SetBool(animationName, true);
        var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(animatorStateInfo.length);
        _animator.SetBool(animationName, false);
    }
}
