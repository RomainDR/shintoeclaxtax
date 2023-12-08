using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ichigo : MonoBehaviour
{
    public static event Action<float> OnMoveForward;
    public static event Action<float> OnMoveRight;
    public static event Action OnDead;
    public static Action<int> OnDammge;

    ControlsIchigo controlInput = null;
    InputAction forward = null;
    InputAction rightmove = null;
    InputAction rotateCam = null;
    InputAction fireBomb = null;

    [SerializeField] int lifemax = 5;
    [SerializeField] CharacterController charaControl = null;
    [SerializeField] float speed = 5;
    [SerializeField] Bomb[] bomb = null;

    int life = 5;
    [SerializeField] SpringArm arm = null;

    float axiscam = 0;

    public int Life { get => life; set => life = value; }
    private void Awake()
    {
        controlInput = new ControlsIchigo();
        OnDammge += OnTakeDammage;
        OnDead += Dead;
    }

    private void FireBomb(InputAction.CallbackContext obj)
    {
        Bomb _bomb = Instantiate(bomb[0]);
        _bomb.Spawn(transform);
    }

    void Start()
    {
        
    }

    void Update()
    {       
        MoveForward();
        MoveRight();
        RotateCam();

    }

    private void Dead()
    {
        OnMoveForward = null;
        OnMoveRight = null;
        OnDead = null;
        Destroy(gameObject);

    }

    private void MoveRight()
    {
        float _moveRight = rightmove.ReadValue<float>();
        charaControl.SimpleMove(arm.Cam.transform.right * _moveRight* speed);
        if (_moveRight > 0)
            transform.eulerAngles = arm.Cam.transform.right * _moveRight;
        if (_moveRight < 0)
            transform.eulerAngles = arm.Cam.transform.right * _moveRight;
        OnMoveRight?.Invoke(_moveRight);
    }

    void MoveForward()
    {
        float _moveforward = forward.ReadValue<float>();
        charaControl.SimpleMove(arm.Cam.transform.forward * _moveforward * 10);
        if(_moveforward > 0)
            transform.rotation = arm.Cam.transform.rotation;
        if(_moveforward < 0)
            transform.rotation = arm.Cam.transform.rotation;

        OnMoveForward?.Invoke(_moveforward);
    }

    private void RotateCam()
    {
        axiscam += rotateCam.ReadValue<float>();
        arm.RotateSpring(axiscam);

    }

    private void OnEnable()
    {
        forward = controlInput.Movement.Forward;
        forward.Enable();
        rightmove= controlInput.Movement.Right;
        rightmove.Enable();
        rotateCam = controlInput.Movement.RotateCam;
        rotateCam.Enable();
        fireBomb = controlInput.Movement.Bombe;
        fireBomb.Enable();
        fireBomb.performed += FireBomb;
    }

    private void OnDisable()
    {
        forward.Disable();
        rightmove.Disable();
        rotateCam.Disable();
        fireBomb.Disable();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Projectil>())
            OnTakeDammage();
    }
    void OnTakeDammage(int _dammage = 1)
    {
        life -= _dammage;
        if (life < 0)
            OnDead?.Invoke();
    }
}
