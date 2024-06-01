using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class chestSlotInfo : MonoBehaviour,IPointerClickHandler
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
    private GameObject _parentFastSlot;

   
    void Start()
    {
        _parentFastSlot = GameObject.Find("InventoryPanel");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var _replic = false;
        for(int j = 0; _parentFastSlot.transform.childCount > j; j++)//обработка повторок
        {
            var _slotGO = gameObject.GetComponent<chestSlotInfo>();
            var _slot = _parentFastSlot.transform.GetChild(j).GetComponent<slotInfo>();
            if (_slot._itemIndex == _slotGO._itemIndex)
            {
                if (_slot._count < _slot._maxCount)
                {
                    _slot._count++;
                    _parentFastSlot.transform.GetChild(j).GetChild(1).GetComponent<TMP_Text>().text =
                    _slot._count.ToString();
                    _replic = true;
                    if (_slotGO._count > 1)
                    {
                        _slotGO._count--;
                        gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text =
                        _slotGO._count.ToString();
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
                    }
                    GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
                    GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveChest();
                    break;
                }
            }
        }
        if (_replic == false)
        {
            for (int i = 0; _parentFastSlot.transform.childCount >= i; i++)//добовление в быстрый слот
            {
                var _slotGO = gameObject.GetComponent<chestSlotInfo>();
                var _slot = _parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>();
                if (_slot._itemIndex == 0)
                {
                    _parentFastSlot.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = gameObject.GetComponent<chestSlotInfo>()
                       ._prefabForLocation.GetComponent<itemInfo>().item.Icon;
                    var _image = _parentFastSlot.transform.GetChild(i).GetChild(0).GetComponent<Image>();
                    var _tempColor = _image.color;
                    _tempColor.a = 1f;
                    _image.color = _tempColor;//поставили нужную иконку                    
                    _slot._itemIndex = _slotGO._itemIndex;
                    _slot._count = 1;
                    _parentFastSlot.transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text =
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
                       
                    }
                    GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
                    GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveChest();
                    break;
                
            }
            }
        }
    }
}
