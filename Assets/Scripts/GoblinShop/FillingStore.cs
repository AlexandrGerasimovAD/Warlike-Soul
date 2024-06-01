using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillingStore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var _itemsScript = Resources.LoadAll<parentItemInfo>("ItemScript");//загружаю все итемы из папки
        transform.GetChild(0).gameObject.SetActive(true);//открываем магазин заполняем закрываем
        var _parentSlots = GameObject.Find("mainShopPanel");
        for(int i = 0; i < _parentSlots.transform.childCount; i++)//рандомный предмет слоты по счету
        {
            var _item = _itemsScript[UnityEngine.Random.Range(0, _itemsScript.Length)];
            var _slot = _parentSlots.transform.GetChild(i).gameObject;
            var _byCount = _slot.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
            _byCount.text = _item._byCount.ToString();
            var _deccription = _slot.transform.GetChild(1).GetComponent<TMP_Text>();
            _deccription.text = _item.descriptionItem;
            var _icon = _slot.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite=_item.Icon;
            var _slotInfo = _slot.transform.GetChild(0).GetComponent<ShopSlotInfo>();
            _slotInfo._itemIndex = _item.id;
            _slotInfo._count = _item.countItem;
            _slotInfo._maxCount = _item.maxCount;
            _slotInfo._rashodnik = _item._rashodnik;
            _slotInfo._gameItem = _item._gameItem;
            _slotInfo._typeWeapoon = _item._typeWeapoon;
            _slotInfo._heel = _item._heel;
            _slotInfo._prefabForPlayer = _item.prefabforPlayer;
            _slotInfo._prefabForLocation = _item.prefabforLocation;
            _slotInfo._byCount = _item._byCount;
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
