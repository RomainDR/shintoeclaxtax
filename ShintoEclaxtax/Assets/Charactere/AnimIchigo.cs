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
        animator.SetFloat("Speed", _axis);
    }
    void SetRightMove(float _axis)
    {
        animator.SetFloat("SpeedRight", _axis);
    }
}
