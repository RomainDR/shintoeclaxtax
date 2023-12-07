using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimIchigo : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Awake()
    {
        Ichigo.OnMove += SetMove;
    }
    void SetMove(Vector3 _axis)
    {
        if (_axis.z != 0)
            animator.SetFloat("Speed", _axis.z);
        else if (_axis.x != 0 )
            animator.SetFloat("Speed", _axis.x);
        else
            animator.SetFloat("Speed", 0);

    }
}
