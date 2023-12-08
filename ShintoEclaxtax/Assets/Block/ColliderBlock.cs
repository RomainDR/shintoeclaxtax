using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class ColliderBlock : MonoBehaviour
{
    public event Action<Collider> OnCollisionEnter;

    private void OnTriggerEnter(Collider other)
    {
        OnCollisionEnter?.Invoke(other);
        Debug.Log("trigger");
    }
}
