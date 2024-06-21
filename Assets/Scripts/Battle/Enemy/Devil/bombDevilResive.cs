using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombDevilResive : MonoBehaviour
{
    private GameObject _playerHp;
    private GameObject _player;
    private int _domage=250;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHp = GameObject.Find("playerHpSlider");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerHp.GetComponent<HpSlider>().addHp(-_domage);
        }
    }
}
