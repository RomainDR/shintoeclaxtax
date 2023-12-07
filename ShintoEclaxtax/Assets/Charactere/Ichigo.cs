using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ichigo : MonoBehaviour
{
    public static event Action<Vector3> OnMove;

    [SerializeField] int lifemax = 5;
    [SerializeField] CharacterController charaControl = null;
    [SerializeField] float speed = 5;
    int life = 5;
    ControlsIchigo controlInput = null;
    InputAction movement = null;
    bool hasBomb = false;

    private void Awake()
    {
        controlInput = new ControlsIchigo();
    }
    void Start()
    {
        
    }

    void Update()
    {
        Move();
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
        movement = controlInput.Movement.Forward;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
