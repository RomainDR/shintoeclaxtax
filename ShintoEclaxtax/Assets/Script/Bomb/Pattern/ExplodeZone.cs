using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(TimerCustom))]
public class ExplodeZone : MonoBehaviour
{
	[SerializeField] protected float size;
	[SerializeField] protected int damage;
	[SerializeField] protected int playerDamage;
	[SerializeField] protected TimerCustom timer;

	public virtual void Init(Vector3 _position) { }
	public virtual void Delete() { Destroy(gameObject); }

	public virtual void OnTriggerEnter(Collider _other)
	{
		TestPlayer _player = _other.GetComponent<TestPlayer>();
		if (!_player) return;
		_player.DamagePlayer(playerDamage);
	}

}
