using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTrigerForAnim : MonoBehaviour
{

    private GameObject _player;
    public Animator _animator1;
    public Animator _animator3;
    public Animator _animator2;
    public GameObject _goblin1;
    public GameObject _goblin2;
    public GameObject _goblin3;
    void Start()
    {
    _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator1.SetBool("Player", true);
            _animator2.SetBool("Player", true);
            _animator3.SetBool("Player", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator1.SetBool("Player", false);
            _animator2.SetBool("Player", false);
            _animator3.SetBool("Player", false);
            _goblin1.transform.LookAt(_goblin3.transform.position);//смотреть друг на друга
            _goblin2.transform.LookAt(_goblin1.transform.position); 
            _goblin3.transform.LookAt(_goblin2.transform.position);  
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _player)
        {
           _goblin1.transform.LookAt(_player.transform.position);//смотреть на игрока  
           _goblin2.transform.LookAt(_player.transform.position);//смотреть на игрока  
           _goblin3.transform.LookAt(_player.transform.position);//смотреть на игрока  
        }
    }
}
