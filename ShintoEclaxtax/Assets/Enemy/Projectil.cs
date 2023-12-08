using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField] float speed = 5;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * speed, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Sniper _sinper = other.GetComponent<Sniper>();
        if (_sinper)
            return;
        Destroy(gameObject);

    }
}
