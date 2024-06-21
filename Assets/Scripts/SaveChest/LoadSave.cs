using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadSave : MonoBehaviour
{
    private GameObject _parentFastSlot;
    private GameObject _parentChestSlot;
    // Start is called before the first frame update
    void Start()
    {
       _parentFastSlot = GameObject.Find("InventoryPanel");
       _parentChestSlot = GameObject.Find("chest").transform.GetChild(0).GetChild(1).gameObject;
       loadFastSlot();//�������� ��� ������� ����
       loadChest();//�������� ������� ��� ������� ����
    }
 public void saveFastSlot()
    {
        var _listFastSlot=new List<int>();
        var _listCountItems = new List<int>();
        var _chilCount = _parentFastSlot.transform.childCount;
        for (int i = 0;_chilCount>i; i++)//��������� � ���� ��� id ��������� �� ������
        {
            var _indexItem = _parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>()._itemIndex;
            _listFastSlot.Add(_indexItem);
            var _countItem = _parentFastSlot.transform.GetChild(i).GetComponent<slotInfo>()._count;
            _listCountItems.Add(_countItem);
        }
        for (int j = 0; j < _listFastSlot.Count; j++)
        { //�������� ��� id
            PlayerPrefs.SetInt("saveFastSlot" + j, _listFastSlot[j]);
            PlayerPrefs.SetInt("saveCountItem" + j, _listCountItems[j]);
        }
    }
    public void loadFastSlot()
    {
        var _items = Resources.LoadAll<parentItemInfo>("ItemScript");//�������� ��� ����� �� �����
        for (int j = 0; j <= _parentFastSlot.transform.childCount; j++)//�������� ������ ����
        {
           var _getId= PlayerPrefs.GetInt("saveFastSlot" + j);
            var _countItem = PlayerPrefs.GetInt("saveCountItem" + j);
            if (_getId != 0)
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    if (_getId == _items[i].id)//������ ���������� � �������� ������ � ����
                    {
                        var _slot = _parentFastSlot.transform.GetChild(j).GetComponent<slotInfo>();
                        _slot._itemIndex = _items[i].id;
                        _parentFastSlot.transform.GetChild(j).GetChild(0).GetComponent<Image>().sprite = _items[i].Icon;              
                        var _image = _parentFastSlot.transform.GetChild(j).GetChild(0).GetComponent<Image>();
                        var _tempColor = _image.color;
                        _tempColor.a = 1f;
                        _image.color = _tempColor;//��������� ������ ������
                        _slot._count = _countItem;//�������� ������ ���� � ����������� � ��������� �� ����
                        if (_slot._count > 1)
                        {
                         _parentFastSlot.transform.GetChild(j).GetChild(1).GetComponent<TMP_Text>().text = _slot._count.ToString();
                        }
                        _slot._maxCount = _items[i].maxCount;
                        _slot._rashodnik = _items[i]._rashodnik;
                        _slot._gameItem = _items[i]._gameItem;
                        _slot._typeWeapoon = _items[i]._typeWeapoon;
                        _slot._heel = _items[i]._heel;
                        _slot._prefabForPlayer = _items[i].prefabforPlayer;
                        _slot._prefabForLocation = _items[i].prefabforLocation;
                    }
                }
            }
        }          
    }
    public void saveChest()
    {
        var _listChestSlot = new List<int>();
        var _listCountItems = new List<int>();
        var _chilCount = _parentChestSlot.transform.childCount;
        for (int i = 0; _chilCount > i; i++)//��������� � ���� ��� id ��������� �� ������
        {
            var _indexItem = _parentChestSlot.transform.GetChild(i).GetComponent<chestSlotInfo>()._itemIndex;
            _listChestSlot.Add(_indexItem);
            var _countItem = _parentChestSlot.transform.GetChild(i).GetComponent<chestSlotInfo>()._count;
            _listCountItems.Add(_countItem);
        }
        for (int j = 0; j < _listChestSlot.Count; j++)
        { //�������� ��� id
            PlayerPrefs.SetInt("saveChestSlot" + j, _listChestSlot[j]);
            PlayerPrefs.SetInt("saveCountChest" + j, _listCountItems[j]);
        }
    }
    public void loadChest()
    {
        var _items = Resources.LoadAll<parentItemInfo>("ItemScript");//�������� ��� ����� �� �����
        for (int j = 0;j< _parentChestSlot.transform.childCount; j++)//�������� ������ ����
        {
            var _getId = PlayerPrefs.GetInt("saveChestSlot" + j);
            var _countItem = PlayerPrefs.GetInt("saveCountChest" + j);
            if (_getId != 0)
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    if (_getId == _items[i].id)//������ ���������� � �������� ������ � ����
                    {
                        var _slot = _parentChestSlot.transform.GetChild(j).GetComponent<chestSlotInfo>();
                        _slot._itemIndex = _items[i].id;
                        _parentChestSlot.transform.GetChild(j).GetChild(0).GetComponent<Image>().sprite = _items[i].Icon;
                        var _image = _parentChestSlot.transform.GetChild(j).GetChild(0).GetComponent<Image>();
                        var _tempColor = _image.color;
                        _tempColor.a = 1f;
                        _image.color = _tempColor;//��������� ������ ������
                        _slot._count = _countItem;//�������� ������ ���� � ����������� � ��������� �� ����
                        if (_slot._count > 1)
                        {
                            _parentChestSlot.transform.GetChild(j).GetChild(1).GetComponent<TMP_Text>().text = _slot._count.ToString();
                        }
                        _slot._maxCount = _items[i].maxCount;
                        _slot._rashodnik = _items[i]._rashodnik;
                        _slot._gameItem = _items[i]._gameItem;
                        _slot._typeWeapoon = _items[i]._typeWeapoon;
                        _slot._heel = _items[i]._heel;
                        _slot._prefabForPlayer = _items[i].prefabforPlayer;
                        _slot._prefabForLocation = _items[i].prefabforLocation;
                    }
                }
            }
        }
    }
  

}
