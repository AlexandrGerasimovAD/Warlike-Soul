using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatleManager : MonoBehaviour
{
    public Transform parent;
    private List<parentItemInfo> itemList = new List<parentItemInfo>();
    private List<parentItemInfo> potionList = new List<parentItemInfo>();
    private GameObject _coin;
    public void voidUnBlocking()
    {
        Invoke("destroyBlocking", 1f);
        Invoke("destroyBlocking", 2f);
        Invoke("destroyBlocking", 3f);
        _coin = GameObject.Find("dataSave").transform.GetChild(0).gameObject;
        object[] giveItems = Resources.LoadAll<parentItemInfo>("ItemScript");
        foreach (parentItemInfo giveEnemyObject in giveItems)
        {
            parentItemInfo listObject = (parentItemInfo)giveEnemyObject;
            itemList.Add(listObject);
        }
        object[] givePotions = Resources.LoadAll<parentItemInfo>("Potions");
        foreach (parentItemInfo giveEnemyObject in givePotions)
        {
            parentItemInfo listObject = (parentItemInfo)giveEnemyObject;
            potionList.Add(listObject);
        }
    }
    private void destroyBlocking()//уничтожение перегородок 
    {
        var _enemyCount = 0;
        for(int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).CompareTag("MainEnemy"))
            {
                _enemyCount++;
            }
        }
        if (_enemyCount == 0)
        {
            for(int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).CompareTag("blockWall"))
                {
                    Destroy(parent.GetChild(i).gameObject);
                }
            }
        }
    }
    public void dropItem(Transform _point,int _coinCount,Transform _parent)
    {
        var _randomInt = UnityEngine.Random.Range(1, 20);
        if (_randomInt == 2 || _randomInt == 6 || _randomInt == 10)
        {
            //spawn item
            int _itemIndex = UnityEngine.Random.Range(0, itemList.Count);
            var _itemObj = itemList[_itemIndex].prefabforLocation;
            var _item = Instantiate(_itemObj);
            _item.transform.SetParent(_parent.transform);
            _item.transform.position = new Vector3(_point.position.x, _point.position.y + (float)1.5, _point.position.z);
        }
        if (_randomInt == 4 || _randomInt == 11)
        {
            // spawn potion
            int _potionIndex = UnityEngine.Random.Range(0, potionList.Count);
            var _potionObj = potionList[_potionIndex].prefabforLocation;
            var _potion = Instantiate(_potionObj);
            _potion.transform.SetParent(_parent.transform);
            _potion.transform.position = new Vector3(_point.position.x, _point.position.y + (float)1.5, _point.position.z);
        }
        if (_randomInt == 1 || _randomInt == 8)
        {
            //spawn coin
            var _spawn = Instantiate(_coin);
            _spawn.transform.SetParent(_parent.transform);
            _spawn.gameObject.SetActive(true);
            _spawn.transform.position = new Vector3(_point.position.x,_point.position.y+2,_point.position.z);
            _spawn.GetComponent<itemUpDownPosition>()._coinCount = _coinCount;
        }
    }
}
