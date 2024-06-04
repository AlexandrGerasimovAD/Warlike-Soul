using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinDomageObj : MonoBehaviour
{
    private GameObject _player;
    private GameObject _hpPlayer;
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _hpPlayer = GameObject.Find("playerHpSlider");
        _enemy = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _hpPlayer.GetComponent<HpSlider>().addHp(-_enemy.GetComponent<EnemyInfo>()._enemyInfo._domage);
        }
    }
}
