using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] ColliderBlock forwardCollider;
    [SerializeField] ColliderBlock backCollider;
    [SerializeField] ColliderBlock rightCollider;
    [SerializeField] ColliderBlock leftCollider;
    [SerializeField] GravityCollider gravityCollider;
    [SerializeField] LayerMask outLayer;
    protected Vector3 newDirection = Vector3.zero;
    protected float speed = 5;
    protected bool isMove = false;
    [SerializeField] float speedGravity = 2;
    protected bool gravity = false;

    private void Awake()
    {
        forwardCollider.OnCollisionEnter += CollisionForward;
        backCollider.OnCollisionEnter += CollisionBack;
        rightCollider.OnCollisionEnter += CollisionRight;
        leftCollider.OnCollisionEnter += CollisionLeft;
        gravityCollider.OnColliderExit += ColliseionGravity;
    }

    private void ColliseionGravity()
    {

        gravity = true;
    }

    protected virtual void Update()
    {
        if (gravity)
            RaycastGravity();
    }

    private void RaycastGravity()
    {
        Ray _ray = new Ray(new Vector3(transform.position.x, transform.position.y - (transform.lossyScale.y / 2), transform.position.z), -transform.up);
        bool hit = Physics.Raycast(_ray.origin, _ray.direction,out RaycastHit _result, 0.5f, outLayer);
        Debug.DrawRay(_ray.origin, _ray.direction* 0.5f, Color.red);
        if (hit)
            if(_result.distance <= 0.1f)
                gravity = false;

        if(!hit || _result.distance >= 0.1f)
            Gravity();
    }

    private void Gravity()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.up * speedGravity, Time.deltaTime);
    }

    public virtual void CollisionForward(Collider _collider)
    {
 
    }
    public virtual void CollisionBack(Collider _collider)
    {

    }
    public virtual void CollisionRight(Collider _collider)
    {
    }
    public virtual void CollisionLeft(Collider _collider)
    { 
    }
    protected void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position+ newDirection, Time.deltaTime);
    }
}
