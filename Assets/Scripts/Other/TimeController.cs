using UnityEngine;

public class TimeController : MonoBehaviour
{
	public static TimeController Instance { get; private set; } = null;
	public float FullDay => _fullDay;
	public float CurrentTime => _currentTime;
	public Weekday Weekday => _weekday;

	[SerializeField] private Transform _directionalLight;
	[SerializeField] private float _fullDay = 120f;
	[Range(0, 1)] 
	[SerializeField] private float _currentTime;
	[SerializeField] private Weekday _weekday;
	private float _hour, _minutes;
	private TimeData timeData;

	private void Awake()
	{
		if (Instance != null)
			Debug.LogError("Another object TimeController already exist!");
		else
			Instance = this;
	}

    private void Start()
    {
		timeData = gameObject.AddComponent<TimeData>();
		timeData.Load(Instance);
		_currentTime = timeData.SavedData.CurrentTime;
		_weekday = timeData.SavedData.Weekday;
	}

    private void Update()
	{
		_currentTime += Time.deltaTime / _fullDay;

		if (_currentTime >= 1)
        {
			_currentTime = 0;
			_weekday++;

			if (_weekday > Weekday.Sunday)
				_weekday = Weekday.Monday;
		}

		_directionalLight.localRotation = Quaternion.Euler((_currentTime * 360f) - 90, 170, 0);
	}

	private void TimeCount()
	{
		_hour = 24 * _currentTime;
		_minutes = 60 * (_hour - Mathf.Floor(_hour));
	}

}
