using System;
using UnityEngine;

public class TimerCustom : MonoBehaviour
{
	[SerializeField] float timerEnd;

	float timer;
	bool isStarted;
	public event Action OnTimerStop;
	public event Action OnTimerStart;
	public event Action OnTimerRestart;

	public bool IsEnd => timer >= timerEnd;
	private void Awake()
	{
		timer = 0;
	}

	public void Update()
	{
		if (!isStarted) return;
		timer += Time.deltaTime;
		if (timer > timerEnd)
			StopTimer();
	}
	public void StartTimer()
	{
		isStarted = true;
		OnTimerStart?.Invoke();
	}

	public void StopTimer()
	{
		isStarted = false;
		OnTimerStop?.Invoke();
	}

	internal void Restart()
	{
		timer = 0;
		OnTimerRestart?.Invoke();
	}
}
