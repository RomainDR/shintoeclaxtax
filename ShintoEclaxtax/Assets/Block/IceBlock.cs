using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class IceBlock : Block
{

    protected override void Update()
    {
        base.Update();
        if (gravity)
            return;
        Move();
    }

    public override void CollisionForward(Collider _collider)
    {
        base.CollisionForward(_collider);
        Ichigo _player = _collider.GetComponent<Ichigo>();
        if (_player)
        {
            newDirection = - transform.forward* speed;
            return;
        }
        newDirection = Vector3.zero;
    }
    public override void CollisionBack(Collider _collider)
    {
        base.CollisionBack(_collider);
        Ichigo _player = _collider.GetComponent<Ichigo>();
        if (_player)
        {
            newDirection = transform.forward * speed;
            return;
        }

        newDirection = Vector3.zero;
    }
    public override void CollisionRight(Collider _collider)
    {
        base.CollisionRight(_collider);

        Ichigo _player = _collider.GetComponent<Ichigo>();
        if (_player)
        { 
            newDirection = transform.right * speed;
            return;
        }

        newDirection = Vector3.zero;
    }
    public override void CollisionLeft(Collider _collider)
    {
        base.CollisionLeft(_collider);

        Ichigo _player = _collider.GetComponent<Ichigo>();
        if (_player )
        {
            newDirection = transform.right * speed;
            return;
        }

        newDirection = Vector3.zero;
    }

}