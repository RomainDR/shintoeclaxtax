using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerCustom : MonoBehaviour
{
	[SerializeField] float timerEnd;

	float timer;
	bool isStarted;

	public bool IsEnd => timer >= timerEnd;

	public void Update()
	{
		if (!isStarted) return;
		timer += Time.deltaTime;
		if (timer > timerEnd)
			StopTimer();
	}
	public void StartTimer() => isStarted = true;

	public void StopTimer() => isStarted = false;

}
