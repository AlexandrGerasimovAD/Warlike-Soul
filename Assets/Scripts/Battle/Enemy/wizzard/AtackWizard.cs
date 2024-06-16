using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackWizard : MonoBehaviour
{
    private GameObject _player;
    public GameObject _enemy;
    private Animator _animator;
    public GameObject _weapoonEffect;
    public GameObject _atackObj;
    private bool _atackDeley = true;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = _enemy.GetComponent<Animator>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _player&&_atackDeley==true)
        {
            _atackDeley = false;
            Invoke("atackDeley", _enemy.GetComponent<EnemyInfo>()._enemyInfo._deleyAttack);
            _enemy.transform.parent.GetComponent<trigerForWalkWizzard>()._attackDeley = true;
            _animator.SetTrigger("Atack");
            Invoke("weapoonEffectActive", 1.2f);
            Invoke("weapoonEffectDeActive", 3.5f);
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
        _enemy.transform.parent.GetComponent<trigerForWalkWizzard>()._attackDeley = false;
    }
    private void atackDeley()
    {
        _atackDeley = true;
    }
    private void setBall()
    {
        var _ball = Instantiate(_atackObj, _enemy.transform);
        _ball.gameObject.SetActive(true);
        _ball.GetComponent<AtackObjDomage>()._domage = _enemy.GetComponent<EnemyInfo>()._enemyInfo._domage;
        Destroy(_ball, 3);
    }
}
