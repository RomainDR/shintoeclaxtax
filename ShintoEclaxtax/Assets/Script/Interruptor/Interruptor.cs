using UnityEngine;

public class Interruptor : ActivableObject
{
	[SerializeField] bool isEnabled = false;
	[SerializeField] MovablePlateform[] movableObjects;

	public override void Enable()
	{
		isEnabled = true;
		foreach (MovablePlateform _obj in movableObjects)
			_obj?.Enable();
	}
	public override void Disable() 
	{ 
		isEnabled = false;
		foreach (MovablePlateform _obj in movableObjects)
			_obj?.Disable();
	} 
	public override bool IsEnabled => isEnabled;

}