using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class takeForInventory : MonoBehaviour
{
    private GameObject _player;
    private GameObject _inventoryPanel;
    private bool _replice = false;
    private GameObject _flip1;
    private GameObject _flip2;
    private GameObject _flip3;
    private GameObject _flip4;
    private float _position;
    private float _offPosition;
    private bool _upTransform = true;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventoryPanel = GameObject.Find("InventoryPanel");
        _flip1 = GameObject.Find("flip1");
        _flip2 = GameObject.Find("flip2");
        _flip3 = GameObject.Find("flip3");
        _flip4 = GameObject.Find("flip4");
        _position = gameObject.transform.localPosition.y * 1.2f;
        _offPosition = gameObject.transform.localPosition.y / 1.2f;      
    }
    private void FixedUpdate()
    {
        if (_upTransform == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.014f,
            transform.localPosition.z);
            if (transform.localPosition.y > _position)
            {
                _upTransform = false;
            }

        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.014f,
            transform.localPosition.z);
            if (transform.localPosition.y < _offPosition)
            {
                _upTransform = true;
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject == _player)
        {                      
            for (int i = 0; _inventoryPanel.transform.childCount > i; i++)//логика по€вление кнопок замены при фулл инвент
            {
                if (_inventoryPanel.transform.GetChild(i).GetComponent<slotInfo>()._itemIndex != 0)
                {
                    pushItem(gameObject.GetComponent<itemInfo>());
                }
                else
                {
                }
                   if(_inventoryPanel.transform.GetChild(i).GetComponent<slotInfo>()._itemIndex==
                   gameObject.GetComponent<itemInfo>().item.id)
                   {
                            if(_inventoryPanel.transform.GetChild(i).GetComponent<slotInfo>()._full==true||
                               gameObject.GetComponent<itemInfo>().item.maxCount==1)
                            {
                                  pushItem(gameObject.GetComponent<itemInfo>());
                    }
                            else { pushItem(null); }
                   }           
            }          
            for (int j = 0; _inventoryPanel.transform.childCount > j; j++)//добовление повторок
            {
                var _slotInfoRep = _inventoryPanel.transform.GetChild(j).GetComponent<slotInfo>();
                if (_slotInfoRep._itemIndex == gameObject.GetComponent<itemInfo>().item.id)
                {
                    var _slotRep = _inventoryPanel.transform.GetChild(j);
                    if (_slotInfoRep._count < _slotInfoRep._maxCount - 1)
                    {
                        _slotInfoRep._count++;
                        var _textCountRep = _slotRep.GetChild(1).GetComponent<TMP_Text>();
                        _textCountRep.text = _slotInfoRep._count.ToString();
                        _replice = true;
                        pushItem(null);
                        Destroy(gameObject);
                        break;
                    }//€чейка €вл€етьс€ полностью заполненной
                    if (_slotInfoRep._count + 1 == _slotInfoRep._maxCount)
                    {
                        _slotInfoRep._full = true;
                    }
                }
            }          
            for (int i = 0; _inventoryPanel.transform.childCount > i; i++)//добовление в инвентарь
            {
                var _slotInfo = _inventoryPanel.transform.GetChild(i).GetComponent<slotInfo>();
                if (_slotInfo._itemIndex == 0 && _replice == false)
                {
                    var _slot = _inventoryPanel.transform.GetChild(i);
                    var _image = _slot.GetChild(0).GetComponent<Image>();
                    var _tempColor = _image.color;
                    _tempColor.a = 1f;
                    _image.color = _tempColor;
                    _slot.GetChild(0).GetComponent<Image>().sprite = gameObject.GetComponent<itemInfo>().item.Icon;
                    _slotInfo._itemIndex = gameObject.GetComponent<itemInfo>().item.id;
                    _slotInfo._count = gameObject.GetComponent<itemInfo>().item.countItem;
                    _slotInfo._maxCount = gameObject.GetComponent<itemInfo>().item.maxCount;
                    if (gameObject.GetComponent<itemInfo>().item.maxCount > 1)//textCount
                    {
                        var _textCount = _slot.GetChild(1).GetComponent<TMP_Text>();
                        _textCount.text = gameObject.GetComponent<itemInfo>().item.countItem.ToString();
                    }
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }     
    private void OnTriggerStay(Collider other)
    {     
        if (_flip1.GetComponent<flipButtom>()._isClick == true)
        {
            Destroy(gameObject);
        }
        if (_flip2.GetComponent<flipButtom>()._isClick == true)
        {
            Destroy(gameObject);
        }
        if (_flip3.GetComponent<flipButtom>()._isClick == true)
        {
            Destroy(gameObject);
        }
        if (_flip4.GetComponent<flipButtom>()._isClick == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pushItem(null);
    }

    private void pushItem(itemInfo item)
    {
        _flip1.GetComponent<flipButtom>()._item = item;
        _flip2.GetComponent<flipButtom>()._item = item;
        _flip3.GetComponent<flipButtom>()._item = item;
        _flip4.GetComponent<flipButtom>()._item = item;
    }
}
