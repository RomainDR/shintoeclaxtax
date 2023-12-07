using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    [SerializeField] Camera cam = null;
    [SerializeField] int lenght = 10;

    void Start()
    {
        
    }

    void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        Ray _ray = new Ray(transform.position,-transform.forward);
        Physics.Raycast(_ray, out RaycastHit _hitInfo, lenght);
        Debug.DrawRay(_ray.origin,_ray.direction);
    }
    void Postition()
    {

    }
}
