using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayer : MonoBehaviour
{
	[SerializeField] Bomb bombRef;

	[SerializeField] float timer = 0;
	[SerializeField] float timerBetweenBomb = 1;
	[SerializeField] int life = 2;
	[SerializeField] Slider lifeBar = null;

	public Action<int> OnTakeDamage;

	[SerializeField] TMP_Text textBomb;

	public void Start()
	{
		/*
		OnTakeDamage += DamagePlayer;
		textBomb.text = bombRef.Name;*/
		
	}
	public void Update()
	{
		if (!bombRef) return;
        timer += Time.deltaTime;
		if (timer > timerBetweenBomb)
		{
			timer = 0;
			Bomb _bomb = Instantiate(bombRef);
			_bomb.Spawn(transform);
		}
	}
	public void DamagePlayer(int _damage)
	{
		life = (life - _damage) < 0 ? 0 : life - _damage;

		if (!lifeBar) throw new Exception("Lifebar is invalid");
		
		lifeBar.value = life - 0.1f;

		if (life == 0)
			Destroy(gameObject);
	}
}
