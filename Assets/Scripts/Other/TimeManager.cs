using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	public float CurrentTime => currentTime;
	[SerializeField] private Text _gameTime; // вывод текста
	[SerializeField] private Transform directionalLight; // основной источник света
	[SerializeField] private float fullDay = 120f; // сколько длиться день, в секундах
	[Range(0, 1)] 
	[SerializeField] private float currentTime; // текущее время суток
	[SerializeField] private Weekday _weekday;
	private Save<TimeData> _timeSave;

	private float h, m;
	private string hour, min;

	void Start()
	{
		_timeSave = new Save<TimeData>("TimeData");
		_timeSave.LoadData();
		if(_timeSave.Data != null)
        {
			DateTime exitTime = DateTime.Parse(_timeSave.Data.ExitTime);
			TimeSpan deltaTime = DateTime.Now - exitTime;
			currentTime = _timeSave.Data.CurrentTime + ((float)deltaTime.TotalSeconds / fullDay);

			_weekday = _timeSave.Data.Weekday;
		}
		//_gameTime.text = "00:00";
	}

	void Update()
	{
		//TimeCount();

		currentTime += Time.deltaTime / fullDay;

		if (currentTime >= 1)
        {
			currentTime = 0;
			if (_weekday == Weekday.Sunday)
				_weekday = Weekday.Monday;
			else
				_weekday++;
		}


		directionalLight.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 170, 0);
	}

	void TimeCount()
	{
		h = 24 * currentTime;
		m = 60 * (h - Mathf.Floor(h));

		if (m < 10) min = "0" + (int)m; else min = ((int)m).ToString();
		if (h < 10) hour = "0" + (int)h; else hour = ((int)h).ToString();

		_gameTime.text = hour + ":" + min;
	}

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
		TimeData timeData = new TimeData() { CurrentTime = currentTime };
		_timeSave.SaveData(timeData);
    }
#endif
	private void OnApplicationQuit()
	{
		TimeData timeData = new TimeData() { ExitTime = DateTime.Now.ToString(), CurrentTime = currentTime, Weekday = _weekday };
		_timeSave.SaveData(timeData);
	}

}
