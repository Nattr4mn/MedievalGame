using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public bool IsOpen { get; private set; }
    public Window CurrentWindow { get; protected set; } = null;

    public delegate void OpenEventHandler(Window sendet);
    public event OpenEventHandler OnOpen;

    private void Awake()
    {
        UIManager.Instance.Windows.Add(this);
    }

    public void Open()
    {
        IsOpen = true;
        OnOpen?.Invoke(this);
    }

    protected abstract void SelfOpen();

    public void Close()
    {
        IsOpen = false;
        if (CurrentWindow != null)
            CurrentWindow.Close();
    }

    protected abstract void SelfClose();

    protected void ChangeCurrentWindow(Window sender)
    {
        if (CurrentWindow != null)
            CurrentWindow.Close();

        CurrentWindow = sender;
    }
}
