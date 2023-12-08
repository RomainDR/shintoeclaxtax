using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    [SerializeField] Camera cam = null;
    [SerializeField] LayerMask outLayer;
    [SerializeField] float armLength = 10;
    [SerializeField] float offsetHeight = 10;

    float distance = 0;
    public Camera Cam => cam;

    public Vector3 CenterCharacter => transform.position + new Vector3(0, 0.5f, 0);

    public Vector3 OffsetHeight => new Vector3(0, offsetHeight, 0);
    public Vector3 FinalPosition => AlphaPosition();


    public Vector3 AlphaPosition()
    {
        Ray ray = new Ray(CenterCharacter, (transform.forward * -armLength) + OffsetHeight);
        bool _hit = Physics.Raycast(ray.origin, ray.direction * armLength, out RaycastHit _hitInfo, armLength, outLayer);
        if (_hit)
            return _hitInfo.point;
        return cam.transform.position + OffsetHeight;

    }

    void Start()
    {
        cam.transform.position = FinalPosition;
    }
    void LateUpdate()
    {
        cam.transform.LookAt(transform.position + new Vector3(0,2,0));
        //cam.transform.position = FinalPosition;
        AlphaPosition();
       RayCast();
    }
    public void RotateSpring(float _angle)
    {
        /*float _x = Mathf.Cos(_angle * Mathf.Deg2Rad) * distance,
            _y = Mathf.Sin(_angle * Mathf.Deg2Rad) * distance;
        Vector3 _lerp = Vector3.Lerp(cam.transform.position, transform.position + new Vector3(_x, offsetCamera.y, _y), Time.time);
        cam.transform.position = _lerp;*/
    }


    private void RayCast()
    {
        Ray ray = new Ray(CenterCharacter, (transform.forward * -armLength) + OffsetHeight);
        Debug.DrawRay(ray.origin, ray.direction * armLength, Color.red);
        /*if (_hit)
            PostitionCam(_hitInfo);*/

    }
    private void OnDrawGizmos()
    {
        //ray = new Ray(transform.position, -transform.forward);
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(ray.origin, transform.position + Cam );
    }
}
