using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(FarmObjectLevel))]
[RequireComponent(typeof(Structure))]
public abstract class AbstractFarmObject : MonoBehaviour
{
    public abstract IItem ÑurrentObject { get; }
    public float Production => _production;
    public float Water => _water;
    public float Harvest => _harvest;
    public float Experience => _experience;
    public bool Occupied => _occupied;
    public bool CanCollect => _canCollect;
    public FarmObjectLevel Level => _level;
    public Structure Structure => _structure;
    public Player Player => _player;
    public UnityEvent Events;

    [SerializeField]    protected List<GameObject>  _spawnList;
    [SerializeField]    protected float             _productionTime = 36f;
                        protected float             _production = 0f;
                        protected float             _water = 0f;
                        protected float             _harvest;
                        protected float             _experience;
                        protected bool              _occupied = false;
                        protected bool              _canCollect = false;

    [SerializeField] private Player _player;
    private FarmObjectLevel _level;
    private Structure _structure;

    public abstract void Fill(IItem item);
    public abstract void Collecting();
    public abstract IEnumerator ProcessOfGrowth();
    public abstract IEnumerator TimerToDestroy();

    private void Start()
    {
        _level = GetComponent<FarmObjectLevel>();
        _structure = GetComponent<Structure>();
        _structure.Init(_player);
    }

    public virtual void PourWater()
    {
        PlayerItems playerItems = _player.Items;
        _water += playerItems.Bucket.Value;
        playerItems.Bucket.Value = 0;

        if (_water > 1)
            _water = 1;
    }

    protected virtual IEnumerator Processing(string objectParent, string obj, bool state)
    {
        _player.Input.Collecting();
        yield return new WaitForSeconds(3f);
        transform.Find(objectParent).transform.Find(obj).gameObject.SetActive(state);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Outline>().enabled = true;
            _player = other.GetComponent<Player>();
            Events?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Outline>().enabled = false;
            _player = null;
            Events?.Invoke();
        }
    }
}
