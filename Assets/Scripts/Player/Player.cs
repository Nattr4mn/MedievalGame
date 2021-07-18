using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Loader<Player>
{
    public PlayerMoveController MoveController => _playerMoveController;
    public PlayerCharacteristics Characteristics => _playerCharacteristics;
    public PlayerResources Resources => _playerResources;
    public Animator Animator => _animator;
    public bool isWorking = false;

    [SerializeField] private GameObject _playerObject;
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private List<AssetItem> itemList;      //temporarily for the test
    [SerializeField] private List<AssetItem> seedsList;     //temporarily for the test

    private PlayerMoveController _playerMoveController;
    private PlayerCharacteristics _playerCharacteristics;
    private PlayerResources _playerResources;

    private void Awake()
    {
        _playerMoveController = _playerObject.AddComponent<PlayerMoveController>();
        _playerCharacteristics = gameObject.AddComponent<PlayerCharacteristics>();
        _playerResources = gameObject.AddComponent<PlayerResources>();

        _playerMoveController.Init(_playerSpeed, _playerRB);
        _playerResources.Init(itemList, seedsList);

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!isWorking)
        {
            if(UIManager.Instance.Vertical != 0)
            {
                _playerMoveController.PlayerMove();


                _animator.SetBool("isRunning", true);
                if (UIManager.Instance.Vertical > 0)
                    _playerMoveController.PlayerRotate(90f * UIManager.Instance.Horizontal);
                else if (UIManager.Instance.Vertical < 0)
                    _playerMoveController.PlayerRotate(180f + (-90f) * UIManager.Instance.Horizontal);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }  
    }
}
