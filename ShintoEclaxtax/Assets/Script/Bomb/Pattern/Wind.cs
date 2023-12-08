using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(TimerCustom))]
public class Wind : MonoBehaviour
{
	[SerializeField] Rigidbody body;
	[SerializeField] TimerCustom timerLife;
	[SerializeField] float speed;

	List<GameObject> objectPicked = new();

	private void Start()
	{
		body = GetComponent<Rigidbody>();
	}
	public void Init(Vector3 _position, int _angle)
	{
		transform.eulerAngles = new Vector3(0, _angle, 0);
		transform.position = _position + new Vector3(0, 1, 0) + (transform.forward * 3);
		timerLife.StartTimer();
	}
	private void LateUpdate()
	{
		body.AddForce(transform.forward * speed);
		foreach(GameObject obj in objectPicked)
			obj.transform.position = transform.position;
		if (timerLife.IsEnd)
			Destroy(gameObject);
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawCube(transform.position, Vector3.one * 0.8f);
	}

	private void OnTriggerEnter(Collider other)
	{
		objectPicked.Clear();
		objectPicked.Add(other.gameObject);
	}
}
