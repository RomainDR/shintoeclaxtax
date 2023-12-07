using UnityEngine;

public class FireExplode : ExplodeZone
{
	[SerializeField] Collider vertical;
	[SerializeField] Collider horizontal;

	#region transform
	Transform TransfVertical => vertical.transform;
	Transform TransfHorizontal => horizontal.transform;
	BoxCollider CastBox(Collider _collider) => (BoxCollider)_collider;
	#endregion transform

	public override void Init(Vector3 _position)
	{
		TransfVertical.position = TransfHorizontal.position = _position;
		CastBox(horizontal).size = new Vector3(size, 1, 1);
		CastBox(vertical).size = new Vector3(1, 1, size);
		timer.StartTimer();
	}

	private void Update()
	{		
		if (timer.IsEnd)
			Delete();
	}

	private void OnDrawGizmos()
	{
		if (!vertical || !horizontal) throw new System.Exception("One of collider is null");
		Gizmos.color = Color.red;

		Gizmos.DrawWireCube(transform.position, CastBox(horizontal).size);
		Gizmos.DrawWireCube(transform.position, CastBox(vertical).size);
	}
}
