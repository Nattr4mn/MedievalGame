using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ActivatableObject))]
public class ImprovementShed : MonoBehaviour
{
    [SerializeField] private List<AbstractFarmObject> FarmObjects;

    private void Start()
    {
        FarmObjects = FarmObjects.OrderBy(farmObject => farmObject.Level.PlayerLevelToUnlock).ToList();
    }

    public void Upgrade(AbstractFarmObject farmObject)
    {
        var obj = FarmObjects.Find(x => x == farmObject);
        obj.Level.LevelUp();
    }

    public void Build(AbstractFarmObject farmObject)
    {
        var obj = FarmObjects.Find(x => x == farmObject);
        obj.IsActive = true;
    }

    public IEnumerable<AbstractFarmObject> GetObjects()
    {
        foreach (var farmObject in FarmObjects)
            yield return farmObject;
    }
}
