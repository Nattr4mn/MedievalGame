using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(FarmObjectLevel))]
public abstract class AbstractFarmObject : MonoBehaviour
{
    public abstract IItem ÑurrentObject { get; }
    public Player Player => _player;
    public float Production => _production;
    public float Water => _water;
    public float Harvest => _harvest;
    public float Experience => _experience;
    public bool Occupied => _occupied;
    public bool CanCollect => _canCollect;
    public FarmObjectLevel Level;
    public bool IsActive = false;

    [SerializeField]    protected UnityEvent        Events;
    [SerializeField]    protected List<GameObject>  _spawnList;
    [SerializeField]    protected float             _productionTime = 36f;
                        protected Player            _player;
                        protected float             _production = 0f;
                        protected float             _water = 0f;
                        protected float             _harvest;
                        protected float             _experience;
                        protected bool              _occupied = false;
                        protected bool              _canCollect = false;

    public abstract void Fill(IItem item);
    public abstract void Collecting();
    public abstract IEnumerator ProcessOfGrowth();
    public abstract IEnumerator TimerToDestroy();

    private void Start()
    {
        Level = GetComponent<FarmObjectLevel>();
        gameObject.SetActive(IsActive);
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
