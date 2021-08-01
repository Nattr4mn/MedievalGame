using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Outline))]
public abstract class FarmObject : MonoBehaviour
{
    public abstract IItem ÑurrentObject { get; }
    public Player Player => _player;
    public int Level { get => _level; set => _level = value; }
    public bool IsActive { get => _isActive; set => _isActive = value; }
    public float Production => _production;
    public float Water => _water;
    public float Harvest => _harvest;
    public float Experience => _experience;
    public bool Occupied => _occupied;
    public bool CanCollect => _canCollect;

    [SerializeField]    protected UnityEvent        Events;
    [SerializeField]    protected List<GameObject>  _spawnList;
    [SerializeField]    protected float             _productionTime = 36f;
    [SerializeField]    protected bool              _isActive = false;
                        protected Player            _player;
                        protected int               _level = 0;
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
        if(_isActive)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
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
