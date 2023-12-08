using System;
using UnityEngine;

[RequireComponent(typeof(TimerCustom))]
public class ExplodeZone : MonoBehaviour
{
	[SerializeField] protected float size;
	[SerializeField] protected int damage;
	[SerializeField] protected TimerCustom timer;

	int damagePlayer = 0;

	private void Start()
	{
		timer = GetComponent<TimerCustom>();
	}
	public virtual void Init(Vector3 _position) { }
	public virtual void Delete() { Destroy(gameObject); }

	public virtual void OnTriggerEnter(Collider _other)
	{
		Ichigo _player = _other.GetComponent<Ichigo>();
		//TestPlayer _player = _other.GetComponent<TestPlayer>();
		if (!_player) return;
		Debug.Log(damage);
		Ichigo.OnDammge?.Invoke(damagePlayer);

    }

	internal void SetDamage(int _damage) => damagePlayer = _damage;

	public virtual TimerCustom Timer => timer;

}
