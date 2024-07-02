using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawnWin : MonoBehaviour
{
    private List<GameObject> itemList = new List<GameObject>();
    private GameObject _coin;

    // Start is called before the first frame update
    void Start()
    {
        _coin = GameObject.Find("dataSave").transform.GetChild(0).gameObject;
        object[] giveItems = Resources.LoadAll<GameObject>("bossDrop");
        foreach (GameObject giveEnemyObject in giveItems)
        {
            GameObject listObject = (GameObject)giveEnemyObject;
            itemList.Add(listObject);
        }
        var _randomInt = UnityEngine.Random.Range(1,3);
        if (_randomInt == 1)
        {
            //spawn coin
            var _spawn = Instantiate(_coin);
            _spawn.transform.SetParent(transform.parent);
            _spawn.gameObject.SetActive(true);
            _spawn.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            _spawn.GetComponent<itemUpDownPosition>()._coinCount = 200;
        }
        if (_randomInt == 2)
        {
            //spawn item
            int _itemIndex = UnityEngine.Random.Range(0, itemList.Count);
            var _itemObj = itemList[_itemIndex];
            var _item = Instantiate(_itemObj);
            _item.transform.SetParent(transform.parent);
            _item.transform.position = new Vector3(transform.position.x, transform.position.y + (float)1.5, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
