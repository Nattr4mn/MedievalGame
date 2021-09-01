using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectionButton
{
    void Init(AbstractFarmUI farmUi, IFarmProduct product);
    void Action();
}
