using MedievalGame.Player;
using UnityEngine;

public class Well : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            gameObject.GetComponent<Outline>().enabled = true;
            InputUI.Instance.Action += player.Bucket.FillBucket;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            gameObject.GetComponent<Outline>().enabled = false;
            InputUI.Instance.Action -= player.Bucket.FillBucket;
        }
    }
}
