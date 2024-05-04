using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private FixedJoystick _joystick;
    private Animator _animator;
    private CharacterController _characterController;
    public float _speedMove;
    private Vector3 _vectorMove;
    public bool _isMoving=true;
    public float _deleyStan;
    private float _speedSave;
    // Start is called before the first frame update
    void Start()
    {
        _joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _speedSave = _speedMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving == true)//данный код должен принимать бул фолс и делей запустить таймер и поставить тру по истечению
        {
            move();
        }
    }
    private void move()
    {
        Vector3 _dirForward = Camera.main.transform.forward;//узнаю где вектор вперед
        _dirForward.y = 0f;
        _dirForward.Normalize();
        Vector3 _dirRight = Camera.main.transform.right;
        _dirRight.y = 0f;
        _dirRight.Normalize();
        _vectorMove = Vector3.zero;//обнул€ю вектор перемещени€
        _vectorMove.x = _joystick.Horizontal;
        _vectorMove.z = _joystick.Vertical;//получаю с джойстика направление +ниже можно добавить по y
        Vector3 _moveDirectionForward = _dirForward * _vectorMove.z;
        Vector3 _moveDirectionSide = _dirRight * _vectorMove.x;
        Vector3 _direction = (_moveDirectionForward + _moveDirectionSide).normalized;
        Vector3 _distance = _direction * _speedMove * Time.deltaTime;//создаю контроьный вектор 
        _characterController.Move(_distance);
        if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)//анимирование передвижени€ в зависимости от значений джойстик
        {
            _animator.SetBool("Stop", true);
            _animator.SetBool("RunToGun", false);
            _animator.SetBool("LeftRun", false);
            _animator.SetBool("RightRun", false);
            _animator.SetBool("BackRun", false);
        }
        if (_joystick.Horizontal < -0.2)
        {
            _animator.SetBool("Stop", false);
            _animator.SetBool("LeftRun", true);
            _animator.SetBool("BackRun", false);
            _animator.SetBool("RightRun", false);
            _animator.SetBool("RunToGun", false);
            _speedMove = 4;
        }
        if (_joystick.Horizontal > 0.2)
        {
            _animator.SetBool("Stop", false);
            _animator.SetBool("RightRun", true);
            _animator.SetBool("LeftRun", false);
            _animator.SetBool("RunToGun", false);
            _animator.SetBool("BackRun", false);
            _speedMove = 4;
        }
        if (_joystick.Vertical > 0.1)
        {
            _animator.SetBool("Stop", false);
            _animator.SetBool("RunToGun", true);
            _animator.SetBool("BackRun", false);
            _animator.SetBool("RightRun", false);
            _animator.SetBool("LeftRun", false);
            _speedMove = _speedSave;
        }
        if (_joystick.Vertical < -0.1)
        {
            _animator.SetBool("Stop", false);
            _animator.SetBool("BackRun", true);
            _animator.SetBool("RightRun", false);
            _animator.SetBool("LeftRun", false);
            _animator.SetBool("RightRun", false);
            _speedMove = 2;
        }
    }
}
