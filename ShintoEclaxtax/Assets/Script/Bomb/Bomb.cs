using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(TimerCustom))]
public class Bomb : MonoBehaviour
{
	/*[SerializeField] float velocity;*/
	[SerializeField] Vector3 offsetSpawned = Vector3.zero;
	[SerializeField] float forceUp = 10;
	[SerializeField] float forceForward = 10;
	[SerializeField] string nameBomb = "patate";
	[SerializeField] int damageToPlayer = 3;

	[SerializeField] TimerCustom timer;
	[SerializeField] ExplodeZone pattern;
	[SerializeField] Rigidbody body;

	private void Start()
	{
		timer = GetComponent<TimerCustom>();
		body = GetComponent<Rigidbody>();
	}
	public string Name => nameBomb;

	private void Update()
	{
		if(timer.IsEnd)
			Explode();
	}
	public virtual void Spawn(Transform _player)
	{
		transform.position = _player.position + offsetSpawned;
		body.AddForce((transform.up * forceUp) + (_player.forward * forceForward));
		timer.StartTimer();
	}
	public virtual void Explode()
	{
		if (!pattern) throw new System.Exception($"Pattern is invalid in {name}");
		ExplodeZone _explosion = Instantiate(pattern);
		_explosion.SetDamage(damageToPlayer);
		_explosion.Init(transform.position);
		Destroy(gameObject);
	}
}

