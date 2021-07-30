using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectionButton
{
    void Init(FarmUI farmUi, IItem item);
    void Action();
}
