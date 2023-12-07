using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    [SerializeField] Camera cam = null;
    [SerializeField] float lenght = 10;
    [SerializeField] float upperCamera = 10;
    [SerializeField] Vector3 finalPositionCam = Vector3.zero;
    [SerializeField] LayerMask outLayer;
    [SerializeField] bool isIgnore = false;

    float distance = 0;
    Vector3 finalPosition = Vector3.zero;

    public Vector3 FinalPosition => transform.position + finalPositionCam;

    void Start()
    {
        finalPosition = transform.position + new Vector3(0, upperCamera, -lenght);
        cam.transform.position = transform.position + FinalPosition;
        distance = Vector3.Distance(cam.transform.position, transform.position);

    }
    void Update()
    {
        cam.transform.position = FinalPosition;
        distance = Vector3.Distance(cam.transform.position, transform.position);


        cam.transform.LookAt(transform.position + new Vector3(0,2,0));
        if (!isIgnore)
            RayCast();
    }
    public void RotateSpring(float _angle)
    {
        Vector2 _newPosition = GetTrigo(_angle);
        lenght = _newPosition.y;
        finalPositionCam = new Vector3(_newPosition.x, 0, _newPosition.y);
    }

    private Vector2 GetTrigo(float _angle)
    {
        float _x = Mathf.Cos(_angle * Mathf.Deg2Rad) * distance,
            _y = Mathf.Sin(_angle * Mathf.Deg2Rad) * distance;
        return new Vector2(_x, _y);
    }

    private void RayCast()
    {
        Ray ray = new Ray(transform.position, finalPosition);
        bool _hit = Physics.Raycast(ray.origin,ray.direction, out RaycastHit _hitInfo, distance, outLayer);
        Debug.DrawRay(ray.origin, ray.direction* distance, Color.red);
        if(_hit)
            PostitionCam(_hitInfo);
    }
    private void OnDrawGizmos()
    {
        //ray = new Ray(transform.position, -transform.forward);
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(ray.origin, transform.position + Cam );
    }
    void PostitionCam(RaycastHit _hit)
    {
        cam.transform.position = _hit.point;
    }
}
