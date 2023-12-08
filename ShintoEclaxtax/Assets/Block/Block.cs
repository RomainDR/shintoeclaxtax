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
    protected Vector3 newDirection;
    protected float speed = 5;
    protected bool isMove = false;

    private void Awake()
    {
        forwardCollider.OnCollisionEnter += CollisionForward;
        backCollider.OnCollisionEnter += CollisionBack;
        rightCollider.OnCollisionEnter += CollisionRight;
        leftCollider.OnCollisionEnter += CollisionLeft;
        newDirection = transform.position;
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
        transform.position = Vector3.MoveTowards(transform.position,newDirection, Time.deltaTime);
    }
}
