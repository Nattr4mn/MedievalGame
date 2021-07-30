using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZone : MonoBehaviour
{
    [SerializeField] private string _loadSceneName;
    [SerializeField] private float _timeToExit;
    private float _timer = 0;
    private bool _isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _isActive = true;
            StartCoroutine(ExitCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isActive = false;
        }
    }

    private IEnumerator ExitCoroutine()
    {
        while(_timer <= _timeToExit && _isActive)
        {
            _timer += Time.deltaTime;
            yield return null;
        }

        if (_timer >= _timeToExit)
            SceneManager.LoadScene(_loadSceneName);
        else
            _timer = 0;
    }
}
