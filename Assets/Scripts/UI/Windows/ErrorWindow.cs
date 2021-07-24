using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorWindow : MonoBehaviour
{
    [SerializeField] private Text _errorText;

    public void Init(string errorText)
    {
        _errorText.text = errorText;
    }
}
