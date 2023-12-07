using Unity.VisualScripting;
using UnityEngine;

public class IceExplode : ExplodeZone
{
	[SerializeField] Collider sphereCollider;

	public override void Init(Vector3 _position)
	{
		sphereCollider = GetComponent<SphereCollider>();
		sphereCollider.transform.position = _position;
		sphereCollider.transform.localScale = new Vector3(size, size, size);
		timer.StartTimer();
	}
	private void Update()
	{		
		if (timer.IsEnd)
			Delete();
	}

	private void OnDrawGizmos()
	{
		if (!sphereCollider) return;
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, size / 2);
	}
}
