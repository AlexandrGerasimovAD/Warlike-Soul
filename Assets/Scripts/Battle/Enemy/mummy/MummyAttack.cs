using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAttack : MonoBehaviour
{
    private GameObject _player;
    public GameObject _effectAttack;
    public GameObject _enemy;
    private GameObject _hpPlayer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _hpPlayer = GameObject.Find("playerHpSlider");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            var _batleManager = GameObject.Find("BatleLocations").GetComponent<BatleManager>();
            _batleManager.parent =_enemy.transform.parent.parent.parent;
            _batleManager.voidUnBlocking();
            _effectAttack.SetActive(true);
            _effectAttack.transform.SetParent(_enemy.transform.parent.parent.parent);
            _hpPlayer.GetComponent<HpSlider>().addHp(-_enemy.GetComponent<EnemyInfo>()._enemyInfo._domage);           
            Destroy(_enemy.transform.parent.parent.gameObject);
        }
    }

}
