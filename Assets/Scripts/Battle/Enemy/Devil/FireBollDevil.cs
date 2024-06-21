using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBollDevil : MonoBehaviour
{
    private GameObject _playerHp;
    private GameObject _player;
    private int _domage = 100;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHp = GameObject.Find("playerHpSlider");
    }
    private void FixedUpdate()
    {
        gameObject.transform.position += (transform.forward * 25 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerHp.GetComponent<HpSlider>().addHp(-_domage);
        }
        if (other.gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
       
    }
   
}
