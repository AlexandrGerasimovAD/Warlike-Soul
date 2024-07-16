using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPortal : MonoBehaviour
{
    private GameObject _player;
    private GameObject _roomEnterence;
    private GameObject _cam;
    public string _name;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _roomEnterence = GameObject.Find(_name).transform.GetChild(0).gameObject;
        _cam = GameObject.Find("Main Camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
            _player.GetComponent<CharacterController>().enabled = false;
            _roomEnterence.SetActive(true);
            _player.transform.SetParent(_roomEnterence.transform);
            _cam.transform.SetParent(_roomEnterence.transform);
            var _point = _roomEnterence.transform.localPosition;//для удобства работы с координатами 
            if (_name == "Boss1")//не работает но может пригодиться
            {
                var _bossPoint = GameObject.Find("BatleLocations").transform.GetChild(3).GetChild(0).GetChild(0).transform.localPosition;
                _player.transform.SetParent(GameObject.Find("BatleLocations").transform.GetChild(3).GetChild(0));
                _player.transform.localPosition = new Vector3(_bossPoint.x, _bossPoint.y, _bossPoint.z);
            }
            else
            {
                _player.transform.localPosition = new Vector3(_point.x + 20, _point.y, _point.z + 7);
            }
            _player.transform.localPosition = new Vector3(_point.x + 20, _point.y, _point.z + 7);
            _player.GetComponent<CharacterController>().enabled = true;
          

        }
    }
}
