using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] bool useDebug = false;
	[SerializeField] Color colorDebug = Color.red;

	private void OnDrawGizmos()
	{
		if (!useDebug) return;
		Gizmos.color = colorDebug;
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
