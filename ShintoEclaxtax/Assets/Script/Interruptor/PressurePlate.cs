
using UnityEngine;

public class PressurePlate : Interruptor
{

	public void OnTriggerEnter(Collider _other)
	{
		//TestPlayer _player = _other.GetComponent<TestPlayer>();
		Ichigo _player = _other.GetComponent<Ichigo>();
		Debug.Log("Je collide");
		if (!_player) return;
		Enable();
	}
	public void OnTriggerExit(Collider _other)
	{
		//TestPlayer _player = _other.GetComponent<TestPlayer>();
		Ichigo _player = _other.GetComponent<Ichigo>();
		if (!_player) return;
		Disable();
	}
}
