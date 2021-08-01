using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TimeManager : MonoBehaviour
{
	public float CurrentTime => currentTime;
	[SerializeField] private Text _gameTime; // вывод текста
	[SerializeField] private Transform directionalLight; // основной источник света
	[SerializeField] private float fullDay = 120f; // сколько длиться день, в секундах
	[Range(0, 1)] 
	[SerializeField] private float currentTime; // текущее время суток

	private float h, m;
	private string hour, min;

	void Start()
	{
		//_gameTime.text = "00:00";
	}

	void Update()
	{
		//TimeCount();

		currentTime += Time.deltaTime / fullDay;

		if (currentTime >= 1) currentTime = 0; else if (currentTime < 0) currentTime = 0;

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
}
