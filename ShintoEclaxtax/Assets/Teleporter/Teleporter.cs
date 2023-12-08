using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform nextPosition;

    private void OnTriggerEnter(Collider other)
    {
        Ichigo _player = other.GetComponent<Ichigo>();
        if(!_player)
            return;
        Debug.Log(nextPosition.position);
        other.transform.position = nextPosition.position;
        Debug.Log(nextPosition.position + "//" + _player.transform.position);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(nextPosition.position, 1);
    }
}
