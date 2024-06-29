using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trollAttackObj : MonoBehaviour
{
    private GameObject _player;
    private GameObject _enemy;
    private Animation _animator;
    public GameObject _weapoonEffect;
    public GameObject _atackObj;
    public Transform _spawnPoint;
    private bool _atackDeley = true;
    void Start()
    {
        _enemy = gameObject.transform.parent.gameObject;
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = _enemy.GetComponent<Animation>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _player && _atackDeley == true)
        {
            _atackDeley = false;
            Invoke("atackDeley", _enemy.GetComponent<EnemyInfo>()._enemyInfo._deleyAttack);
            _enemy.transform.parent.GetComponent<trigerForWalk>()._attackDeley = true;
            _animator.Play("Attack_02");
            Invoke("idleStart", 2);
            Invoke("weapoonEffectActive", 1f);
            Invoke("weapoonEffectDeActive", 2f);
            Invoke("goWalk", _enemy.GetComponent<EnemyInfo>()._enemyInfo._deleyAtackForTrigerWalk);
            Invoke("setBall", 1.7f);

        }
    }
    private void weapoonEffectActive()
    {
        _weapoonEffect.SetActive(true);
    }
    private void weapoonEffectDeActive()
    {
        _weapoonEffect.SetActive(false);
    }
    private void goWalk()
    {
        _enemy.transform.parent.GetComponent<trigerForWalk>()._attackDeley = false;
    }
    private void atackDeley()
    {
        _atackDeley = true;
    }
    private void setBall()
    {
        var _ball = Instantiate(_atackObj,_spawnPoint);
        _ball.transform.SetParent(_player.transform.parent);
        _ball.gameObject.SetActive(true);
        _ball.GetComponent<fireBall>()._domage = _enemy.GetComponent<EnemyInfo>()._enemyInfo._domage;
        Destroy(_ball, 3);
    }
    private void idleStart()
    {
        _animator.Play("Idle_01");

      
    }
}
