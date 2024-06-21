using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalForBase : MonoBehaviour
{
    private GameObject _player;
    private GameObject _base;
    private GameObject _cam;
    private string _name;
    // Start is called before the first frame update
    void Start()
    {
        _name = transform.parent.parent.parent.GetComponent<StartGenerationRooms>()._nameNext;
        _player = GameObject.FindGameObjectWithTag("Player");
        _base = GameObject.Find("mainBase");
        _cam = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _player.GetComponent<CharacterController>().enabled = false;
            _base.transform.GetChild(0).gameObject.SetActive(true);
            _player.transform.SetParent(_base.transform);
            _cam.transform.SetParent(_base.transform);
            var _point = GameObject.Find("SpawnPoint").transform.localPosition;//для удобства работы с координатами 
            _player.transform.localPosition = new Vector3(_point.x, _point.y, _point.z);
            _player.GetComponent<CharacterController>().enabled = true;
            gameObject.transform.parent.parent.gameObject.SetActive(false);
            if (_name == "BatleLevel2")
            {
                var _location = GameObject.Find("BatleReserv").transform.GetChild(0).gameObject;
                var _spawn = Instantiate(_location);
                _spawn.transform.SetParent(transform.parent.parent.parent.parent);
                _spawn.transform.localPosition = transform.parent.localPosition;
                Destroy(transform.parent.parent.parent.gameObject);
            }
            if (_name == "BatleLevel3")
            {
                var _location = GameObject.Find("BatleReserv").transform.GetChild(1).gameObject;
                var _spawn = Instantiate(_location);
                _spawn.transform.SetParent(transform.parent.parent.parent.parent);
                _spawn.transform.localPosition = transform.parent.localPosition;
                Destroy(transform.parent.parent.parent.gameObject);
            }
            if (_name == "Boss")
            {
                var _location = GameObject.Find("BatleReserv").transform.GetChild(2).gameObject;
                var _spawn = Instantiate(_location);
                _spawn.transform.SetParent(transform.parent.parent.parent.parent);
                _spawn.transform.localPosition = transform.parent.localPosition;
                Destroy(transform.parent.parent.parent.gameObject);
            }
            if (_name == "Base")
            {
                var _location = GameObject.Find("BatleReserv").transform.GetChild(3).gameObject;
                var _spawn = Instantiate(_location);
                _spawn.transform.SetParent(transform.parent.parent.parent.parent);
                _spawn.transform.localPosition = transform.parent.localPosition;
                Destroy(transform.parent.parent.parent.gameObject);
            }
        }
    }
}
