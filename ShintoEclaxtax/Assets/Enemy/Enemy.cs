using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action onTriggerEnter = null;
    public event Action onTriggerExit = null;

    protected Ichigo player;

    public virtual void Awake()
    {
        Ichigo.OnDead += PlayerDead;
    }

    private void PlayerDead()
    {
        player = null;
        CancelInvoke();

    }

    public void Update()
    {
        if (player)
            LookAt();
    }

    private void LookAt()
    {
        transform.LookAt(player.transform.position + new Vector3(0,1,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        Ichigo _ichigo = other.GetComponent<Ichigo>();
        if (!_ichigo) 
            return;
        player = _ichigo;
        onTriggerEnter?.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
        onTriggerExit?.Invoke();
    }
}
