using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Sniper : Enemy
{
    Action OnDead = null;

    [SerializeField] float timer = 2;
    [SerializeField] Transform projectils = null;
    [SerializeField] float life = 5;

    public override void Awake()
    {
        base.Awake();
        onTriggerEnter += HitBoxEnter;
        onTriggerExit += HitBoxExit;
        OnDead += Dead;
    }

    private void Dead()
    {
        player = null;
        CancelInvoke("Shoot");
        Destroy(gameObject);
    }

    private void HitBoxExit()
    {
        CancelInvoke("Shoot");

    }
    private void HitBoxEnter()
    {
        InvokeRepeating("Shoot", timer, timer);
    }
    void Shoot()
    {
        Instantiate(projectils,transform.position,transform.rotation);
    }
    public void Damage(float _damage)
    {
        life -= _damage;

        if (life <= 0)
            OnDead?.Invoke();
    }
}
