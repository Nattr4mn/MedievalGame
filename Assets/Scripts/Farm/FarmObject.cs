using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public abstract class FarmObject : MonoBehaviour
{
    public abstract int Level { get; }
    public abstract float Production { get; }
    public abstract float ProductionTime { get; }
    public abstract float Harvest { get; }
    public abstract float Experience { get; }
    public abstract bool Occupied { get; }
    public abstract bool CanCollect { get; }
    public abstract IItem ÑurrentObject { get; }
    public float Water => _water;
    public Player Player => _player;
    public UnityEvent Events => _events;

    protected float _water = 0f;

    [SerializeField] private UnityEvent _events;
    private Player _player;

    public abstract void Fill(IItem firstItem, IItem secondItem);
    public abstract void Collecting();
    public abstract IEnumerator ProcessOfGrowth();

    public virtual void PourWater()
    {
        PlayerItems playerItems = Player.Items;
        _water += playerItems.Bucket.Count;
        playerItems.Bucket.Count = 0;

        if (_water > 1)
            _water = 1;
    }

    protected IEnumerator Processing(string objectParent, string obj, bool state)
    {
        Player.GetComponentInChildren<Animator>().SetBool("isRunning", false);
        Player.GetComponentInChildren<Animator>().SetTrigger("gathering");
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
