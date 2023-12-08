using UnityEngine;

public class MovablePlateform : Plateform
{
    [SerializeField] protected float moveSpeed = 1.0f;

	public override void Disable()
	{
		base.Disable();
	}
	public override void Enable()
	{
		base.Enable();
	}
}
