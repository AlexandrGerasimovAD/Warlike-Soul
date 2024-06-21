using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalBossInBase : MonoBehaviour
{
    private GameObject _player;
    private GameObject _base;
    private GameObject _cam;
    void Start()
    {
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
            var _location = GameObject.Find("BatleReserv").transform.GetChild(3).gameObject;
            var _spawn = Instantiate(_location);
            _spawn.transform.SetParent(transform.parent.parent.parent.parent.parent);
            _spawn.transform.localPosition = transform.parent.localPosition;
            Destroy(gameObject.transform.parent.parent.parent.parent.gameObject);

        }
    }
}
