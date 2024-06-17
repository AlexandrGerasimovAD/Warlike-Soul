using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGenerationRooms : MonoBehaviour
{
    public GameObject EnterenceRoom;
    public bool _generateRoom = true;
    public int _maxCountRoom;
    public int _countRoom;
    public int _countEnemy;
    public int _minCountEnemy;
    public string _nameNext;
    // Start is called before the first frame update
    void Start()
    {
        var _enerence = Instantiate(EnterenceRoom);
        _enerence.transform.SetParent(transform);
        _enerence.transform.localPosition = transform.localPosition;
        Invoke("voidPortal", 2f);
    }
    private void voidPortal()
    {
        var _childCount = transform.childCount;
        var _room = transform.GetChild(_childCount-1);
        for(int i = 0; i < _room.childCount; i++)
        {
            if (_room.GetChild(i).CompareTag("portalForBatle"))
            {
                _room.GetChild(i).gameObject.SetActive(true);
            }
        }
        for (int i = 0; i < _room.childCount; i++)
        {
            if (_room.GetChild(i).CompareTag("MainEnemy"))
            {
                Destroy(_room.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < _room.childCount; i++)
        {
            if (_room.GetChild(i).CompareTag("blockWall"))
            {
                Destroy(_room.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < _room.childCount; i++)
        {
            if (_room.GetChild(i).CompareTag("spawner"))
            {
                Destroy(_room.GetChild(i).gameObject);
            }
        }
    }

}
