using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Ichigo : MonoBehaviour
{
    public static event Action<float> OnMoveForward;
    public static event Action<float> OnMoveRight;
    public static event Action OnDead;
    public static Action<int> OnDammge;

    public static Action<Bomb> OnPickBomb;
    public int MaxLife => lifemax;
    public Bomb[] Bombs => bomb;

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
    bool isTeleport = false;
    public int Life { get => life; set => life = value; }
    public bool IsTeleport { get =>isTeleport; set => isTeleport = value; }

    private void Awake()
    {
        controlInput = new ControlsIchigo();
        OnDammge += OnTakeDammage;
        OnDead += Dead;
        OnPickBomb += PickupBomb;
    }

    private void FireBomb(InputAction.CallbackContext obj)
    {
        if (bomb.Length <= 0) return;
        Bomb _bomb = Instantiate(bomb[0]);
        _bomb.Spawn(transform);
    }

    void Update()
    {
        if (isTeleport)
            return;
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
        transform.position = Vector3.Lerp(transform.position, transform.position + arm.Cam.transform.right * _moveRight, Time.deltaTime * speed);
        if (_moveRight > 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, arm.Cam.transform.eulerAngles.y + 90, transform.eulerAngles.z);
        if (_moveRight < 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, arm.Cam.transform.eulerAngles.y - 90, transform.eulerAngles.z);
        OnMoveRight?.Invoke(_moveRight);
    }

    void MoveForward()
    {
        float _moveforward = forward.ReadValue<float>();
        charaControl.SimpleMove(arm.Cam.transform.forward * _moveforward * speed);
        if(_moveforward > 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,arm.Cam.transform.eulerAngles.y, transform.eulerAngles.z);
        if(_moveforward < 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, arm.Cam.transform.eulerAngles.y+180, transform.eulerAngles.z);

        OnMoveForward?.Invoke(_moveforward);
    }

    private void RotateCam()
    {
        axiscam += rotateCam.ReadValue<float>();
        arm.SetRotateSpring(axiscam);

    }

    private void OnEnable()
    {
        forward = controlInput.Movement.Forward;
        forward.Enable();
        rightmove = controlInput.Movement.Right;
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

    public void PickupBomb(Bomb collectibleBomb)
    {
        Bomb[] _new = new Bomb[bomb.Length + 1];
        bomb.CopyTo(_new, 0);
        _new[_new.Length - 1] = collectibleBomb;
        bomb = _new;
    }
}
