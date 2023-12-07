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
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, size / 2);
	}

	public override void OnTriggerEnter(Collider _other)
	{
		base.OnTriggerEnter(_other);
		/*ExplodeZone _bomb = _other.GetComponent<ExplodeZone>();
		if (!_bomb) return;
		FireExplode _fireBomb = Cast<FireExplode>(_bomb);
		if (_fireBomb)
		{
			_fireBomb.Timer.StopTimer();
		}*/
	}

	public T Cast<T>(ExplodeZone _bomb) where T : ExplodeZone
	{
		return (T)_bomb;
	}
}
