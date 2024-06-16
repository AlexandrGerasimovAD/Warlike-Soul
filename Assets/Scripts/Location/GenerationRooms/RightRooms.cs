using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRooms : MonoBehaviour
{
    private List<GameObject> roomsList = new List<GameObject>();
    private int _random;
    void Start()
    {
        _random = UnityEngine.Random.Range(1, 3);
        var _levelInfo = transform.parent.parent.parent.GetComponent<StartGenerationRooms>();
        if (_random == 1
            && _levelInfo._generateRoom == true ||_levelInfo._countRoom < 2)
        {
            _levelInfo._countRoom++;
            if (_levelInfo._countRoom >= _levelInfo._maxCountRoom)
            {
                _levelInfo._generateRoom = false;
            }
            object[] Holls = Resources.LoadAll<GameObject>("rooms");
            foreach (GameObject holsObj in Holls)
            {
                GameObject listObject = (GameObject)holsObj;
                roomsList.Add(listObject);
            }
            int indexRandom = UnityEngine.Random.Range(0, roomsList.Count);
            GameObject holl = roomsList[indexRandom];
            var _holl = Instantiate(holl);
            _holl.transform.SetParent(transform);
            _holl.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y
             , transform.localPosition.z);
            _holl.transform.localRotation = Quaternion.Euler(0, 0, -270);
            _holl.transform.SetParent(transform.parent.parent.parent);

            Destroy(transform.parent.gameObject);

        }
    }
}
