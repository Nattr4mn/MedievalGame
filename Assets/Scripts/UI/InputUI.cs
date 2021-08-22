using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rewards))]
public class InputUI : MonoBehaviour
{
    public static InputUI Instance { get; private set; }
    public Button ActionButton => _action;
    public Joystick Joystick => _joystick;
    public Rewards Reward { get; private set; }

    public delegate void ActionHandler();
    public event ActionHandler Action;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _action;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Another instance of PlayerUI already exists!");

        Instance = this;
    }

    private void Start()
    {
        Reward = GetComponent<Rewards>();
    }

    public void OnAction()
    {
        Action?.Invoke();
    }
}
