using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class IceBlock : Block
{

    private void Update()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 5);
    }
    public override void CollisionForward(Collider _collider)
    {
        base.CollisionForward(_collider);
        Ichigo _player = _collider.GetComponent<Ichigo>();
        if (_player)
        {
            newDirection = transform.position- transform.forward* speed;
            return;
        }
        newDirection = transform.position;
    }
    public override void CollisionBack(Collider _collider)
    {
        base.CollisionBack(_collider);
        Ichigo _player = _collider.GetComponent<Ichigo>();
        if (_player)
        {
            newDirection = transform.position + transform.forward * speed;
            return;
        }
        newDirection = transform.position;
    }
    public override void CollisionRight(Collider _collider)
    {
        base.CollisionRight(_collider);

        Ichigo _player = _collider.GetComponent<Ichigo>();
        if (_player)
        { 
            newDirection = transform.position - transform.right * speed;
            return;
        }
        newDirection = transform.position;
    }
    public override void CollisionLeft(Collider _collider)
    {
        base.CollisionLeft(_collider);

        Ichigo _player = _collider.GetComponent<Ichigo>();
        if (_player )
        {
            newDirection = transform.position + transform.right * speed;
            return;
        }
        newDirection = transform.position;
    }

}