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
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventoryPanel = GameObject.Find("InventoryPanel");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            for(int j = 0; _inventoryPanel.transform.childCount>j; j++)//добовление повторок
            {
            var _slotInfoRep = _inventoryPanel.transform.GetChild(j).GetComponent<slotInfo>();
                   if (_slotInfoRep._itemIndex == gameObject.GetComponent<itemInfo>().item.id)
                   {
                            var _slotRep = _inventoryPanel.transform.GetChild(j);
                            if (_slotInfoRep._count < _slotInfoRep._maxCount)
                            {
                                _slotInfoRep._count++;
                                var _textCountRep = _slotRep.GetChild(1).GetComponent<TMP_Text>();
                                _textCountRep.text = _slotInfoRep._count.ToString();
                                _replice = true;
                                Destroy(gameObject);
                                break;
                            }
                   }
            }
           for(int i = 0; _inventoryPanel.transform.childCount>i; i++)//добовление в инвентарь
            {
                var _slotInfo=_inventoryPanel.transform.GetChild(i).GetComponent<slotInfo>();
                if (_slotInfo._itemIndex == 0&&_replice==false)
                {
                    var _slot = _inventoryPanel.transform.GetChild(i);
                    var _image = _slot.GetChild(0).GetComponent<Image>();
                    var _tempColor = _image.color;
                    _tempColor.a = 1f;
                    _image.color = _tempColor;
                    _slot.GetChild(0).GetComponent<Image>().sprite = gameObject.GetComponent<itemInfo>().item.Icon;
                    _slotInfo._itemIndex = gameObject.GetComponent<itemInfo>().item.id;
                    _slotInfo._count = gameObject.GetComponent<itemInfo>().item.countItem;
                    _slotInfo._maxCount= gameObject.GetComponent<itemInfo>().item.maxCount;                    
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
}
