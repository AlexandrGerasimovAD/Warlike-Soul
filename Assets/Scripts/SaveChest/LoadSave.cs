using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadSave : MonoBehaviour
{
    private GameObject _parentFastSlot;
    private GameObject _parentChestSlot;
    // Start is called before the first frame update
    void Start()
    {
        _parentFastSlot = GameObject.Find("InventoryPanel");
        _parentChestSlot = GameObject.Find("chest").transform.GetChild(0).GetChild(1).gameObject;
        loadFastSlot();//загрузка при запуске игры
    }
 public void saveFastSlot()
    {
        var _listFastSlot=new List<int>();
        var _chilCount = _parentFastSlot.transform.childCount;
        for (int i = 0;_chilCount>i; i++)//записываю в лист все id предметов со слотов
        {
            // _listFastSlot.Add(_parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>()._itemIndex);
            var _indexItem = _parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>()._itemIndex;
            _listFastSlot.Add(_indexItem);                             
        }
        for (int j = 0; j < _listFastSlot.Count; j++)//сохроняю эти id
            PlayerPrefs.SetInt("saveFastSlot" + j, _listFastSlot[j]);
    }
    public void loadFastSlot()
    {
        var _items = Resources.LoadAll<parentItemInfo>("ItemScript");//загружаю все итемы из папки
        for (int j = 0; j <= _parentFastSlot.transform.childCount; j++)//проверяю каждый слот
        {
           var _getId= PlayerPrefs.GetInt("saveFastSlot" + j);
            if (_getId != 0)
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    if (_getId == _items[i].id)//нахожу совпадения и загружаю данные в слот
                    {
                        var _slot = _parentFastSlot.transform.GetChild(j).GetComponent<slotInfo>();
                        _slot._itemIndex = _items[i].id;
                    }
                }
            }

        }          



    }
    private void printList(List<int> _list)
    {
        for(int i = 0; i <= _list.Count; i++)
        {
            print(_list[i]);
        }
    }

}
