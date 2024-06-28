using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButtom : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public int _tupeWeapoon;
    public float _deley;
    public float _domage;
    public GameObject _prefabShot;
    private GameObject _player;
    private bool _buttom = false;
    private float _timer;
    private bool _isTimeOff=true;
    private float _timerOffset;
    private Transform _hand;
    private GameObject _cam;
    private Animator _animator;
    private Transform _xAngle;
    private GameObject _fireEffect;
    private GameObject _automatFireEffect;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _hand = GameObject.Find("handCharacter").transform;
        _cam = GameObject.Find("Main Camera");
        _animator = _player.GetComponent<Animator>();
        _fireEffect = GameObject.Find("pistolFire").transform.GetChild(0).gameObject;
        _automatFireEffect = GameObject.Find("AutomatFire").transform.GetChild(0).gameObject;
    }

    void Update()
    {
        //timer
        if (_buttom == true && _isTimeOff == true)
        {
             _timer += Time.deltaTime;
             _timerOffset = 0;
            if (_timer > _deley)
            {//выстрел на сцене                
                _xAngle = _cam.transform;               
                _animator.SetTrigger("atack");
                if (_tupeWeapoon == 2)
                {
                    var _shotEffect = Instantiate(_fireEffect);//эффект при выстрелe
                    _shotEffect.transform.SetParent(_hand.transform.GetChild(0));
                    _shotEffect.transform.position = _hand.transform.GetChild(0).transform.position;
                    _shotEffect.transform.localScale = new Vector3((float)2, (float)2, (float)2);
                    _shotEffect.gameObject.SetActive(true);
                }
                if (_tupeWeapoon == 3)
                {
                    var _shotEffect = Instantiate(_automatFireEffect);//эффект при выстрелe
                    _shotEffect.transform.SetParent(_hand.transform.GetChild(0));
                    _shotEffect.transform.position = _hand.transform.GetChild(0).transform.position;
                    _shotEffect.transform.localScale = new Vector3((float)0.03, (float)0.03, (float)0.03);
                    _shotEffect.gameObject.SetActive(true);
                }
                var _shot = Instantiate(_prefabShot,_xAngle);//что спавним под каким углом спавним,сам патрон
                _shot.transform.SetParent(_player.transform.parent);
                _shot.transform.position = _hand.transform.position;
                _shot.GetComponent<Patron>()._domage = _domage;
                _timer = 0;
            }
        }//closed timer
        else
        {
            _timerOffset += Time.deltaTime;
        }
        if (_timerOffset > _deley)
        {
            _isTimeOff = true;
        }            
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _animator.SetBool("notAttack", false);
        _timer = _deley;
        _buttom = true;        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _buttom = false;
        _isTimeOff = false;
        _animator.SetBool("notAttack",true);
    }
}
