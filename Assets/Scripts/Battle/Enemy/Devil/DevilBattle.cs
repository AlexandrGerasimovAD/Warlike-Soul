using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevilBattle : MonoBehaviour
{
    private GameObject _player;
    private Animator _animator;
    public bool _active = false;
    public GameObject _effectForAttack2;
    public GameObject _effectForAttack1;
    public GameObject _fireBoll;
    public GameObject _splashAttack;
    private Slider _hpSlider;
    public GameObject _dieEffect;
    public bool _resiveDomage=false;
    private bool _die = false;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
        _hpSlider = GameObject.Find("bossHp").transform.GetChild(0).GetChild(1).GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(_player.transform);
        if (_active == true&&_die==false)
        {
            var _typeAttack = UnityEngine.Random.Range(1,6);
            if (_typeAttack == 1||_typeAttack==3||_typeAttack==4||_typeAttack==5)
            {
                _animator.Play("Attack1");
                _effectForAttack1.SetActive(true);
                Invoke("effectAttack1Off", 1.3f);
              var  _typeAtac = UnityEngine.Random.Range(1, 3);
                if (_typeAtac == 2)
                {
                    var _direction = transform.position-_player.transform.position;
                    _direction.Normalize();
                        var _ball = Instantiate(_fireBoll);
                        _ball.transform.SetParent(transform);
                        _ball.gameObject.SetActive(true);
                        _ball.transform.localScale = new Vector3(1, 1, 1);
                        _ball.transform.localRotation = Quaternion.Euler(_direction);
                        _ball.transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y + (float)0.8,
                           transform.localPosition.z);
                    _ball.transform.SetParent(transform.parent);
                    Destroy(_ball, 3);
                    _active = false;
                    Invoke("attackOn", 3);
                }
                else
                {
                    var _countBall= UnityEngine.Random.Range(5,10);
                    for(int i = 0; i < _countBall; i++)
                    {
                        var _direction = transform.position - _player.transform.position;
                        _direction.Normalize();
                        var _ball = Instantiate(_fireBoll,_player.transform);
                        _ball.transform.SetParent(transform);
                        _ball.gameObject.SetActive(true);
                        var x= UnityEngine.Random.Range(-2.1f,2.1f);
                        var z = UnityEngine.Random.Range(-2.1f,2.1f);
                        _ball.transform.localRotation = Quaternion.Euler(_direction);
                        _ball.transform.localPosition = new Vector3(transform.localPosition.x+(float)x
                            ,transform.localPosition.y+(float)0.5                                                       ,
                            transform.localPosition.z+(float)z);
                        _ball.transform.SetParent(transform.parent);
                        Destroy(_ball, 3);
                        _active = false;
                        Invoke("attackOn", 3);
                    }
                }
            }
            if (_typeAttack == 2)
            {
                _animator.Play("Attack2");
                _effectForAttack2.SetActive(true);
                Invoke("_effectAttack2Off",1.6f);
                var _countBall = UnityEngine.Random.Range(3,6);
                for (int i = 0; i < _countBall; i++)
                {
                    var _splash = Instantiate(_splashAttack);
                    _splash.transform.SetParent(transform);
                    _splash.gameObject.SetActive(true);
                    var x = UnityEngine.Random.Range(-17.1f, 17.1f);
                    var z = UnityEngine.Random.Range(-17.1f,-17.1f);
                    _splash.transform.position = new Vector3(_player.transform.position.x +(float)x,
                       _player.transform.position.y + (float)0.1,
                       _player.transform.position.z + (float)0.1);
                    _splash.transform.SetParent(transform.parent);
                    _splash.transform.GetChild(0).transform.SetParent(transform.parent);
                    Destroy(_splash, 3);
                }
                _active = false;
                Invoke("attackOn", 5);
            }            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playerDomage"))
        {
            if (_resiveDomage == true)
            {
                GameObject.Find("bossHp").transform.GetChild(0).gameObject.SetActive(true);
                var _domage = other.gameObject.GetComponent<Patron>()._domage;
                _hpSlider.value -= _domage / 10000;
                if (_hpSlider.value == 0)
                {
                    GameObject.Find("bossHp").transform.GetChild(0).gameObject.SetActive(false);
                    onPortalBase();
                    //запуск панели результатов
                    _die = true;
                    _animator.SetBool("Die", true);
                    _active = false;
                    Destroy(gameObject, 2);
                }
            }
        }
        if (other.gameObject.CompareTag("swordDomage"))
        {
            if (_resiveDomage == true)
            {
                GameObject.Find("bossHp").transform.GetChild(0).gameObject.SetActive(true);
                var _domage = other.gameObject.GetComponent<DomageObjForPlayer>()._domage;
                _hpSlider.value -= _domage / 10000;
                if (_hpSlider.value == 0)
                {
                    GameObject.Find("bossHp").transform.GetChild(0).gameObject.SetActive(false);
                    onPortalBase();
                    //запуск панели результатов
                    _die = true;
                    _animator.SetBool("Die", true);
                    _active = false;
                    Destroy(gameObject, 2);
                }
            }
        }
    }
    private void onPortalBase()
    {
        for(int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).CompareTag("portalForBatle"))
            {
                transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(true);
            }
        }
    }
   
    private void attackOn()
    {
        _active = true;
    }
    private void _effectAttack2Off()
    {
        _effectForAttack2.SetActive(false);
    }
    private void effectAttack1Off()
    {
        _effectForAttack1.SetActive(false);
    }  
}
