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
		IcePlateform _object = _other.GetComponent<IcePlateform>();
		if (_object)
			_object.Enable();

		Sniper _sniper = _other.GetComponent<Sniper>();
		if (_sniper) 
			_sniper.Damage(damage);

		Funtaine _funtain = _other.GetComponent<Funtaine>();
		if( _funtain )
			_funtain.Enable();
	}

	public T CastPlateform<T>(Plateform _plateform) where T : Plateform
	{
		return (T)_plateform;
	}
}
