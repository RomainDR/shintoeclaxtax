using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sniper : Enemy
{
    [SerializeField] float timer = 2;
    [SerializeField] Transform projectils = null;

    public override void Awake()
    {
        base.Awake();
        onTriggerEnter += HitBoxEnter;
        onTriggerExit += HitBoxExit;
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
}
