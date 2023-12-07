using System.ComponentModel;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
	[SerializeField] Bomb bombRef;

	[SerializeField]float timer = 0;
	[SerializeField]int life = 2;

	public void Update()
	{
		timer += Time.deltaTime;
		if (timer > 10)
		{
			timer = 0;
			Bomb _bomb = Instantiate<Bomb>(bombRef);
			_bomb.Spawn(transform.position);
		}
	}
	public void DamagePlayer(int _damage)
	{
		life -= _damage;
		if (life <= 0)
			Destroy(gameObject);
	}
}
