using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpShedUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Action(bool state)
    {
        if (state)
        {
            //GameUI.Instance.ActionEvent += Enable;
        }
        else
        {
            //GameUI.Instance.ActionEvent -= Enable;
        }
    }    
    
    public void Enable()
    {
        //GameUI.Instance.ActionButton.gameObject.SetActive(false);
        _panel.gameObject.SetActive(true);
    }
}
