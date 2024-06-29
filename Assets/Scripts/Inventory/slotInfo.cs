using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slotInfo : MonoBehaviour,IPointerClickHandler
{
    public int _slotIndex;
    public int _itemIndex;
    public int _count;
    public int _maxCount;
    public bool _full;
    public bool _rashodnik;
    public bool _gameItem;
    public int _typeWeapoon;//0 руки 1 меч 2 пистолет 3 автомат
    public int _heel;
    public GameObject _prefabForPlayer;
    public GameObject _prefabForLocation;
    private GameObject _hand;
    private Animator _animator;
    private GameObject _buttomAtack;
    private GameObject _hpSlider;
    private GameObject _chest;
    private void Start()
    {
        _hand = GameObject.Find("handCharacter");
        _buttomAtack = GameObject.Find("AtackButtom");
        _animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        _hpSlider = GameObject.Find("playerHpSlider");
        _chest = GameObject.Find("chest").transform.GetChild(0).gameObject;
    }

    [System.Obsolete]
    public void OnPointerClick(PointerEventData eventData)
    {
        var _replic = false;
        if (_chest.active == true)//если открыт сундук          <--устарело
        {
            var _slotGO = gameObject.GetComponent<slotInfo>();//наш игровой слот
            var _parenSlots = GameObject.Find("savePanel");
            for (int j = 0; _parenSlots.transform.childCount > j; j++)//обработка повторок
            {
                if(_slotGO._itemIndex == _parenSlots.transform.GetChild(j).GetComponent<chestSlotInfo>()._itemIndex)
                {
                    if(_parenSlots.transform.GetChild(j).GetComponent<chestSlotInfo>()._count<
                     _parenSlots.transform.GetChild(j).GetComponent<chestSlotInfo>()._maxCount)
                    { 
                        _parenSlots.transform.GetChild(j).GetComponent<chestSlotInfo>()._count++;
                        _parenSlots.transform.GetChild(j).GetChild(1).GetComponent<TMP_Text>().text =
                        _parenSlots.transform.GetChild(j).GetComponent<chestSlotInfo>()._count.ToString();
                        _replic = true;
                        if (_slotGO._count > 1) //очистка слотов быстрого доступа
                        {
                            _slotGO._count--;
                            gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = _slotGO._count.ToString();
                        }
                        else 
                        {
                            var _imageGo = gameObject.transform.GetChild(0).GetComponent<Image>();
                            var _tempColorGo = _imageGo.color;
                            _tempColorGo.a = 0f;
                            _imageGo.color = _tempColorGo;//поставили нужную иконку
                            gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = null;//очистил текст кол-во
                            _slotGO._itemIndex = 0;
                            _slotGO._count = 0;
                            _slotGO._maxCount = 0;
                            _slotGO._full = false;
                            _slotGO._rashodnik = false;
                            _slotGO._gameItem = false;
                            _slotGO._typeWeapoon = 0;
                            _slotGO._heel = 0;
                            _slotGO._prefabForPlayer = null;
                            _slotGO._prefabForLocation = null;
                            if (_hand.transform.childCount != 0)
                            {
                                Destroy(_hand.transform.GetChild(0).gameObject);
                                _animator.SetInteger("typeWeapoon", 0);
                            }
                        }
                        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
                        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveChest();
                        break;
                    }
                }
                
                
            }
            if (_replic == false)
            {
                for (int i = 0; _parenSlots.transform.childCount >= i; i++)
                {
                    var _slot = _parenSlots.transform.GetChild(i).GetComponent<chestSlotInfo>();
                    if (_slot._itemIndex == 0)
                    {
                        _parenSlots.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = gameObject.GetComponent<slotInfo>()
                        ._prefabForLocation.GetComponent<itemInfo>().item.Icon;
                        var _image = _parenSlots.transform.GetChild(i).GetChild(0).GetComponent<Image>();
                        var _tempColor = _image.color;
                        _tempColor.a = 1f;
                        _image.color = _tempColor;//поставили нужную иконку                    
                        _slot._itemIndex = _slotGO._itemIndex;
                        _slot._count = 1;
                        _parenSlots.transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text =
                        _slot._count.ToString();
                        _slot._maxCount = _slotGO._maxCount;
                        _slot._full = _slotGO._full;
                        _slot._rashodnik = _slotGO._rashodnik;
                        _slot._gameItem = _slotGO._gameItem;
                        _slot._typeWeapoon = _slotGO._typeWeapoon;
                        _slot._heel = _slotGO._heel;
                        _slot._prefabForPlayer = _slotGO._prefabForPlayer;
                        _slot._prefabForLocation = _slotGO._prefabForLocation;
                        //выше перенос данных в слот сундука ниже очищение слота быстрого доступа
                        if (_slotGO._count > 1)
                        {
                            _slotGO._count--;
                            gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = _slotGO._count.ToString();
                        }
                        else
                        {
                            var _imageGo = gameObject.transform.GetChild(0).GetComponent<Image>();
                            var _tempColorGo = _imageGo.color;
                            _tempColorGo.a = 0f;
                            _imageGo.color = _tempColorGo;//поставили нужную иконку
                            gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = null;//очистил текст кол-во
                            _slotGO._itemIndex = 0;
                            _slotGO._count = 0;
                            _slotGO._maxCount = 0;
                            _slotGO._full = false;
                            _slotGO._rashodnik = false;
                            _slotGO._gameItem = false;
                            _slotGO._typeWeapoon = 0;
                            _slotGO._heel = 0;
                            _slotGO._prefabForPlayer = null;
                            _slotGO._prefabForLocation = null;
                            if (_hand.transform.childCount != 0)
                            {
                                Destroy(_hand.transform.GetChild(0).gameObject);
                                _animator.SetInteger("typeWeapoon", 0);
                            }
                        }
                        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
                        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveChest();
                        break;
                    }
                }
            }
        }
        else //если сундук закрыт
        {
            if (gameObject.GetComponent<slotInfo>()._rashodnik == true)
            {
                //код применения расходника
                if (gameObject.GetComponent<slotInfo>()._heel > 0 && _hpSlider.GetComponent<HpSlider>()._hpCount < 1000)
                {
                    _hpSlider.GetComponent<HpSlider>().addHp(gameObject.GetComponent<slotInfo>()._heel);
                    if (gameObject.GetComponent<slotInfo>()._count > 1)//если расходников несколько уменшаю кол-во
                    {
                        gameObject.GetComponent<slotInfo>()._count--;
                        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text
                        = gameObject.GetComponent<slotInfo>()._count.ToString();
                    }
                    else//если расходник 1 обнуляю данные слота-делаю слот пустым
                    {
                        var _slot = gameObject.GetComponent<slotInfo>();
                        _slot._itemIndex = 0;
                        _slot._count = 0;
                        _slot._maxCount = 0;
                        _slot._full = false;
                        _slot._rashodnik = false;
                        _slot._gameItem = false;
                        _slot._typeWeapoon = 0;
                        _slot._heel = 0;
                        _slot._prefabForPlayer = null;
                        _slot._prefabForLocation = null;
                        var _image = gameObject.transform.GetChild(0).GetComponent<Image>();
                        var _tempColor = _image.color;
                        _tempColor.a = 0f;
                        _image.color = _tempColor;
                        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = null;
                    }
                }
            }
            if (gameObject.GetComponent<slotInfo>()._gameItem == true)
            {
                //брать предмет в руки
                if (_hand.transform.childCount != 0)
                {
                    Destroy(_hand.transform.GetChild(0).gameObject);
                }
                if (gameObject.GetComponent<slotInfo>()._typeWeapoon == 0)
                {
                    //включаем анимацию для кулаков
                    _animator.SetInteger("typeWeapoon", 0);
                }
                if (gameObject.GetComponent<slotInfo>()._typeWeapoon == 1)
                {
                    //включаем анимацию для мечей
                    var _item = gameObject.GetComponent<slotInfo>()._prefabForPlayer.GetComponent<itemInfo>().item;//инфо оружия
                    _animator.SetInteger("typeWeapoon", 1);
                    var _spawn = Instantiate(gameObject.GetComponent<slotInfo>()._prefabForPlayer);
                    _spawn.transform.SetParent(_hand.transform);
                    _spawn.transform.localPosition = new Vector3(_hand.transform.localPosition.x+ (float)0.004
                        , _hand.transform.localPosition.y,
                    _hand.transform.localPosition.z-(float)0.004);
                    _spawn.transform.localRotation = Quaternion.Euler(90, 0, 60);//настройка поворота
                    _buttomAtack.GetComponent<AttackButtom>()._deley = _item.delayShot;
                    _buttomAtack.GetComponent<AttackButtom>()._domage = _item.damage;
                    _buttomAtack.GetComponent<AttackButtom>()._prefabShot = _item.prefabShot;
                    _buttomAtack.GetComponent<AttackButtom>()._tupeWeapoon = 1;

                }
                if (gameObject.GetComponent<slotInfo>()._typeWeapoon == 2)
                {
                    //включаем анимацию для пистолета
                    var _item = gameObject.GetComponent<slotInfo>()._prefabForPlayer.GetComponent<itemInfo>().item;//инфо оружия
                    _animator.SetInteger("typeWeapoon", 2);
                    var _spawn = Instantiate(gameObject.GetComponent<slotInfo>()._prefabForPlayer);
                    _spawn.transform.SetParent(_hand.transform);
                    _spawn.transform.localPosition = new Vector3(_hand.transform.localPosition.x, _hand.transform.localPosition.y,
                    _hand.transform.localPosition.z);
                    _spawn.transform.localRotation = Quaternion.Euler(110, 0, 90);
                    _buttomAtack.GetComponent<AttackButtom>()._deley = _item.delayShot;
                    _buttomAtack.GetComponent<AttackButtom>()._domage = _item.damage;
                    _buttomAtack.GetComponent<AttackButtom>()._prefabShot = _item.prefabShot;
                    _buttomAtack.GetComponent<AttackButtom>()._tupeWeapoon =2;
                }
                if (gameObject.GetComponent<slotInfo>()._typeWeapoon == 3)
                {
                    //включаем анимацию для автомата
                    var _item = gameObject.GetComponent<slotInfo>()._prefabForPlayer.GetComponent<itemInfo>().item;//инфо оружия
                    _animator.SetInteger("typeWeapoon", 3);
                    var _spawn = Instantiate(gameObject.GetComponent<slotInfo>()._prefabForPlayer);
                    _spawn.transform.SetParent(_hand.transform);
                    _spawn.transform.localPosition = new Vector3(_hand.transform.localPosition.x, _hand.transform.localPosition.y,
                    _hand.transform.localPosition.z);
                    _spawn.transform.localRotation = Quaternion.Euler(30, -60, -90);//настройка поворота
                    _buttomAtack.GetComponent<AttackButtom>()._deley = _item.delayShot;
                    _buttomAtack.GetComponent<AttackButtom>()._domage = _item.damage;
                    _buttomAtack.GetComponent<AttackButtom>()._prefabShot = _item.prefabShot;
                    _buttomAtack.GetComponent<AttackButtom>()._tupeWeapoon = 3;
                }
            }
        }
    }

}
