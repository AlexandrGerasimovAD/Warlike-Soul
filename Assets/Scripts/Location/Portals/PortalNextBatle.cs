using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNextBatle : MonoBehaviour
{
    private GameObject _player;
    private GameObject _roomEnterence;
    private GameObject _cam;
    private string _name;
    // Start is called before the first frame update
    void Start()
    {
        _name = transform.parent.parent.parent.GetComponent<StartGenerationRooms>()._nameNext;
        _player = GameObject.FindGameObjectWithTag("Player");
        _roomEnterence = GameObject.Find(_name).transform.GetChild(0).gameObject;
        _cam = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _player.GetComponent<CharacterController>().enabled = false;
            _roomEnterence.SetActive(true);
            _player.transform.SetParent(_roomEnterence.transform);
            _cam.transform.SetParent(_roomEnterence.transform);
            var _point = _roomEnterence.transform.localPosition;//��� �������� ������ � ������������ 
            if (_name == "Boss1")//�� �������� �� ����� �����������
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
            if(_name== "BatleLevel2")
            {
                var _location = GameObject.Find("BatleReserv").transform.GetChild(0).gameObject;
                var _spawn = Instantiate(_location);
                _spawn.transform.SetParent(transform.parent.parent.parent.parent);
                Destroy(transform.parent.parent.parent.gameObject);
            }
            if (_name == "BatleLevel3")
            {
                var _location = GameObject.Find("BatleReserv").transform.GetChild(1).gameObject;
                var _spawn = Instantiate(_location);
                _spawn.transform.SetParent(transform.parent.parent.parent.parent);
                Destroy(transform.parent.parent.parent.gameObject);
            }
            if (_name == "Boss")
            {
                var _location = GameObject.Find("BatleReserv").transform.GetChild(2).gameObject;
                var _spawn = Instantiate(_location);
                _spawn.transform.SetParent(transform.parent.parent.parent.parent);
                Destroy(transform.parent.parent.parent.gameObject);
            }
            if (_name == "Base")
            {
                var _location = GameObject.Find("BatleReserv").transform.GetChild(3).gameObject;
                var _spawn = Instantiate(_location);
                _spawn.transform.SetParent(transform.parent.parent.parent.parent);
                Destroy(transform.parent.parent.parent.gameObject);
            }

        }
    }
}