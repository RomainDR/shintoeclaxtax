using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCollider : MonoBehaviour
{
    public event Action<Collider> OnCollisionEnter;
    public event Action OnColliderExit;

    private void Start()
    {
        OnColliderExit?.Invoke();

    }
    private void OnTriggerEnter(Collider other)
    {
        OnCollisionEnter?.Invoke(other);
    }
    
    void OnTriggerExit(Collider other)
    {
        OnColliderExit?.Invoke();
    }
}
