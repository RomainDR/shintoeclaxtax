using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimIchigo : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Awake()
    {
        Ichigo.OnMoveForward += SetMoveForward;
        Ichigo.OnMoveRight += SetRightMove;
    }
    void SetMoveForward(float _axis)
    {
        if (_axis != 0)
            animator.SetBool("Right", false);
        animator.SetFloat("SpeedForward", _axis);

    }
    void SetRightMove(float _axis)
    {
        if(_axis!=0)
            animator.SetBool("Right", true);
        animator.SetFloat("SpeedRight", _axis);
    }
}
