using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Teleporter : MonoBehaviour
{
    static public event Action<Vector3> OnTeleport = null;
    [SerializeField] Transform nextPosition;
        Timer timer = new();


    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        Ichigo _player = other.GetComponent<Ichigo>();
        if(!_player)
            return;
        _player.IsTeleport = true;
        timer.Interval = 100;
        timer.Elapsed += (s, e) =>
        {
            _player.IsTeleport = false;
            timer.Stop();
        };
        _player.transform.position = nextPosition.position;
        timer.Start();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(nextPosition.position, 1);
    }
}
