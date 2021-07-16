using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestManager : Loader<ForestManager>
{
    [SerializeField] private List<GameObject> forestFruitList;
    [SerializeField] private int _numberOfObjects;
    [SerializeField] private float _density;
    [SerializeField] private LayerMask _mask;

    private void Awake()
    {
        List<Vector2> spawnPoints = new List<Vector2>();
        var perlinNoise = Mathf.PerlinNoise(200f, 200f);
        //Player.Instance.gameObject.transform.position;
        for(int i = 0; i < _numberOfObjects; i++)
        {
            float x = Random.Range(0f, 100f);
            float z = Random.Range(0f, 100f);
            Vector3 pos = new Vector3(x, 0, z);

            while (Physics.OverlapSphere(pos, _density, _mask).Length != 0 &&
                x == Player.Instance.gameObject.transform.position.x &&
                z == Player.Instance.gameObject.transform.position.z)
            {
                x = Random.Range(0f, 100f);
                z = Random.Range(0f, 100f);
                pos = new Vector3(x, 0, z);
            }

            Instantiate(forestFruitList[Random.Range(0, forestFruitList.Count)], pos, Quaternion.identity, transform);
        }
    }

    
}
