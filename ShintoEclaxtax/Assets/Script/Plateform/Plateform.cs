using UnityEngine;

public class Plateform : ActivableObject
{
	[SerializeField] bool isEnabled;

	public override void Enable() => isEnabled = true;
	public override void Disable() => isEnabled = false;
	public override bool IsEnabled => isEnabled;

	public virtual void ChangeLayer(){ }
}
