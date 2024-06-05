using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinAttack : MonoBehaviour
{
    private GameObject _player;
    private Animator _animator;
    private GameObject _enemy;
    public GameObject _trigerForWalk;
    private float _deleyAttack;
    private bool _atackDeley = true;
    public GameObject _domageObj;
    private float _deleyActiveDomageObj;
    private float _deleyDeActiveDomageObj;
    private float _deleyAttackForTriggerWalk;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemy = transform.parent.gameObject;
        _animator = _enemy.GetComponent<Animator>();
        _deleyAttack = _enemy.GetComponent<EnemyInfo>()._enemyInfo._deleyAttack;
        _deleyActiveDomageObj = _enemy.GetComponent<EnemyInfo>()._enemyInfo._deleyActivDomageObj;
        _deleyDeActiveDomageObj = _enemy.GetComponent<EnemyInfo>()._enemyInfo._deleyDeActivDomageObj;
        _deleyAttackForTriggerWalk = _enemy.GetComponent<EnemyInfo>()._enemyInfo._deleyAtackForTrigerWalk;

    }
    private void OnTriggerStay(Collider other)
    {
        if (_atackDeley == true&&other.gameObject==_player&&_enemy.transform.parent.GetComponent<TrigerForWalk>()._die==false)
        {
            _trigerForWalk.GetComponent<TrigerForWalk>()._attackDeley = true;
            _animator.SetTrigger("Atack");
            Invoke("pushDeleyWalk",_deleyAttackForTriggerWalk);
            _atackDeley = false;
            Invoke("atakTimerDeley", _deleyAttack);
            Invoke("domageObjActive", _deleyActiveDomageObj);
            Invoke("domageObjDeActive", _deleyDeActiveDomageObj);

        }
    }
    private void pushDeleyWalk()
    {
        _trigerForWalk.GetComponent<TrigerForWalk>()._attackDeley = false;
    }
    private void atakTimerDeley()
    {
        _atackDeley = true;
    }
    private void domageObjActive()
    {
        _domageObj.SetActive(true);
    }
    private void domageObjDeActive()
    {
        _domageObj.SetActive(false);
    }
}
