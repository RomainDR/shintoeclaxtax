using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ichigo : MonoBehaviour
{
    public static event Action<Vector3> OnMove;

    ControlsIchigo controlInput = null;
    InputAction movement = null;
    InputAction rotateCam = null;

    [SerializeField] int lifemax = 5;
    [SerializeField] CharacterController charaControl = null;
    [SerializeField] float speed = 5;
    int life = 5;

    SpringArm arm = null;

    bool hasBomb = false;

    private void Awake()
    {
        controlInput = new ControlsIchigo();
        arm = GetComponent<SpringArm>();
        if (!arm)
            Debug.Log("null");
    }
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        RotateCam();
    }

    private void RotateCam()
    {
        float _rotate = rotateCam.ReadValue<float>();
        if(_rotate != 0)
            arm.RotateSpring(_rotate);

    }

    void Move()
    {
        Vector3 _movement = movement.ReadValue<Vector3>();
        charaControl.SimpleMove(_movement);
        transform.eulerAngles = new Vector3(0, _movement.x * 90, 0);
        OnMove?.Invoke(_movement);
    }

    private void OnEnable()
    {
        movement = controlInput.Movement.Move;
        movement.Enable();

        rotateCam = controlInput.Movement.RotateCam;
        rotateCam.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
