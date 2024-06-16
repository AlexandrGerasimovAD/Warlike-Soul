using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlotInfo : MonoBehaviour,IPointerClickHandler
{
    public int _slotIndex;
    public int _itemIndex;
    public int _count;
    public int _maxCount;
    public bool _full;
    public bool _rashodnik;
    public bool _gameItem;
    public int _byCount;
    public int _typeWeapoon;//0 руки 1 меч 2 пистолет 3 автомат
    public int _heel;
    public GameObject _prefabForPlayer;
    public GameObject _prefabForLocation;
    private GameObject _parentFastSlot;
    private bool _replic;

    public void OnPointerClick(PointerEventData eventData)
    {
        _replic = false;
        var _getCoin = PlayerPrefs.GetInt("mainCoinSave");
        if ((_getCoin - _byCount) >= 0)//хватит ли денег на покупку
        {
            _parentFastSlot = GameObject.Find("InventoryPanel").gameObject;
            for(int i = 0; i < _parentFastSlot.transform.childCount; i++)//покупка повторки
            {
                if (_parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>()._itemIndex == _itemIndex)
                {//если повторка 
                    var _fastSlot = _parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>();
                    if (_fastSlot._count < _fastSlot._maxCount)//если есть куда добовлять
                    {
                        _fastSlot._count++;
                        _parentFastSlot.transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text =
                            _fastSlot._count.ToString();
                        _replic = true;
                        //покупка
                        PlayerPrefs.SetInt("mainCoinSave", _getCoin - _byCount);
                        var _pushCoin = PlayerPrefs.GetInt("mainCoinSave");
                        var _coinText = GameObject.Find("textCoin").GetComponent<TMP_Text>();
                        _coinText.text = _pushCoin.ToString();
                        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
                        break;
                    }
                }               
            }
            if (_replic == false)
            {
                for (int i = 0; i < _parentFastSlot.transform.childCount; i++)//покупка в пустой слот
                {
                    if (_parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>()._itemIndex == 0)
                    {
                        var _slot = _parentFastSlot.transform.GetChild(i);
                        var _slotInfo = _parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>();
                        _slot.GetChild(0).GetComponent<Image>().sprite = _prefabForPlayer.GetComponent<itemInfo>().item.Icon;
                        var _image = _slot.GetChild(0).GetComponent<Image>();
                        var _tempColor = _image.color;
                        _tempColor.a = 1f;
                        _image.color = _tempColor;//поставили нужную иконку
                        _slotInfo._itemIndex = _itemIndex;
                        _slotInfo._count = _count;
                        _slotInfo._maxCount = _maxCount;
                        _slotInfo._rashodnik = _rashodnik;
                        _slotInfo._gameItem = _gameItem;
                        _slotInfo._typeWeapoon = _typeWeapoon;
                        _slotInfo._heel = _heel;
                        _slotInfo._prefabForPlayer = _prefabForPlayer;
                        _slotInfo._prefabForLocation = _prefabForLocation;
                        //покупка
                        PlayerPrefs.SetInt("mainCoinSave", _getCoin - _byCount);
                        var _pushCoin = PlayerPrefs.GetInt("mainCoinSave");
                        var _coinText = GameObject.Find("textCoin").GetComponent<TMP_Text>();
                        _coinText.text = _pushCoin.ToString();
                        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
                        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
                        break;
                    }
                    else
                    {
                        //код нет места в инвентаре
                    }
                }
            }

        }
        else
        {
            //код не хватает денег на покупку 
        }
       
    }
}
