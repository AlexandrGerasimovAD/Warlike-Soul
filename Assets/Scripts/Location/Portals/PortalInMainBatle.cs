using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalInMainBatle : MonoBehaviour
{
    private GameObject _player;
    private GameObject _roomEnterence;
    private GameObject _base;
    private GameObject _cam;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
       // _roomEnterence = GameObject.Find("BatleLevel1").transform.GetChild(0).gameObject;
        _base = GameObject.Find("SpawnPoint");
        _cam = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
            _player.GetComponent<CharacterController>().enabled = false;
            //_roomEnterence.SetActive(true);
            GameObject.Find("BatleLevel1").transform.GetChild(0).gameObject.SetActive(true);
            _player.transform.SetParent(GameObject.Find("BatleLevel1").transform.GetChild(0));
            _cam.transform.SetParent(GameObject.Find("BatleLevel1").transform.GetChild(0));
            var _point = GameObject.Find("BatleLevel1").transform.GetChild(0).localPosition;//для удобства работы с координатами 
            _player.transform.localPosition = new Vector3(_point.x + 20, _point.y, _point.z + 7);           
            _player.GetComponent<CharacterController>().enabled = true;
            _base.transform.parent.gameObject.SetActive(false);
        }
    }
}
