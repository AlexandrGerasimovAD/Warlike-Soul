using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigerForWalk : MonoBehaviour
{
    private GameObject _player;
    private GameObject _enemy;
    private Animation _animator;
    public bool _PlayerEnterZone;
    private float _minDistance;
    private float _speed;
    public bool _resiveDomage;
    private bool _walkToPlayer = false;
    public bool _attackDeley = false;
    public bool _die = false;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemy = transform.GetChild(0).gameObject;
        _animator = _enemy.GetComponent<Animation>();
        _minDistance = _enemy.GetComponent<EnemyInfo>()._enemyInfo._minDistance;
        _speed = _enemy.GetComponent<EnemyInfo>()._enemyInfo._speed;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Vector3.Distance(_player.transform.position, _enemy.transform.position) > _minDistance
           && _PlayerEnterZone == true && _attackDeley == false
             || _resiveDomage == true && _attackDeley == false &&
               Vector3.Distance(_player.transform.position, _enemy.transform.position) > _minDistance)
        // если скрипт получил задержку для атаки то движение не возможно пока он снова не получит задержка окончена
        //если растояние между игроком и врагом больше distance то идти к игроку
        //или если враг получил урон и растояние больше минимального то идти к игроку
        {
            _walkToPlayer = true;
            _animator.Play("Walk");
        }
        else//если расстояние меньше distance то остановить анимацию ходьбы
        {
            _walkToPlayer = false;
            if (_attackDeley == false)
            {
                _walkToPlayer = false;
                _animator.Play("Idle_01");
            }
        }
        if (_walkToPlayer == true && _die == false)
        {
            Vector3 _direction = _player.transform.position - _enemy.transform.position;//дистанция между врагом и игроком
            float _moveHorizontal = _direction.x;//углы и напровление            
            float _moveVertical = _direction.z;
            Vector3 _movement = new Vector3(_moveHorizontal, 0, _moveVertical);
            _movement.Normalize();//вектор напровления нормализуем что бы скорость не менялась в зависимости от расстояния 
            Vector3 _move = new Vector3(_movement.x * _speed, 0, _movement.z * _speed);//контрольный вектор
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _player.transform.position, 0.042f);//само перемещение
        }
        if (_PlayerEnterZone == true && _attackDeley == false || _resiveDomage == true && _attackDeley == false)
        {
            _enemy.transform.LookAt(_player.transform.position);//враг смотрит на игрока
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _PlayerEnterZone = true;
        }
    }
}
