using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(TimerCustom))]
public class Bomb : MonoBehaviour
{
	/*[SerializeField] float velocity;*/
	[SerializeField] Vector3 offsetSpawned = Vector3.zero;
	[SerializeField] float forceUp = 10;
	[SerializeField] float forceForward = 10;

	[SerializeField] TimerCustom timer; 
	[SerializeField] ExplodeZone pattern;
	[SerializeField] Rigidbody body;

	private void Update()
	{
		if(timer.IsEnd)
			Explode();
	}
	public virtual void Spawn(Vector3 _position)
	{
		transform.position = _position + offsetSpawned;
		body.AddForce((transform.up * forceUp) + (transform.forward * forceForward));
		timer.StartTimer();
	}
	public virtual void Explode()
	{
		ExplodeZone _explosion = Instantiate<ExplodeZone>(pattern);
		_explosion.Init(transform.position);
		Destroy(gameObject);
	}
}

