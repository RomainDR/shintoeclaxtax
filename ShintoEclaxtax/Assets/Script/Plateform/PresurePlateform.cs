
using UnityEngine;

public class PressurePlateform : MovablePlateform
{
	[SerializeField] Point a = null;
	[SerializeField] Point b = null;

	bool targetB = false;

	bool isAtStart = false;
	public Vector3 APos => a.transform.position;
	public Vector3 BPos => b.transform.position;


	public override void Enable()
	{
		base.Enable();
		isAtStart = false;
	}

	public void LateUpdate()
	{
		if (isAtStart) return;

		if (!IsEnabled)
		{
			if (Vector3.Distance(transform.position, APos) > 0.1f)
				transform.position = Vector3.MoveTowards(transform.position, APos, Time.deltaTime * moveSpeed);
			else if (!isAtStart)
				isAtStart = true;
			return;
		}
		transform.position = Vector3.MoveTowards(transform.position, !targetB ? BPos : APos, Time.deltaTime * moveSpeed);
		if (Vector3.Distance(transform.position, !targetB ? BPos : APos) < 0.1f)
		{
			targetB = !targetB;
		}
	}
	private void OnDrawGizmos()
	{
		if (!useDebug) return;
		Gizmos.color = Color.red;
		Gizmos.DrawLine(APos, BPos);
	}
}
