using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortalInMainBatle : MonoBehaviour
{
    private GameObject _player;
    private GameObject _roomEnterence;
    private GameObject _base;
    private GameObject _cam;
    private bool _weapoonEnabled = false;
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
            GameObject.Find("ParentLoadingPanel").GetComponent<loadingManager>().openLoadingPanel();
            GameObject.Find("AbsManager").GetComponent<RewardCountManager>()._coinCount = 0;
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
            //выдать пистолет если нет оружия
            var _slotPanel = GameObject.Find("InventoryPanel");
            for (int i = 0; i < _slotPanel.transform.childCount; i++)
            {
                var _slot = _slotPanel.transform.GetChild(i);
                var _slotInfo = _slot.GetComponent<slotInfo>();
                if (_slotInfo._gameItem)
                {
                    _weapoonEnabled = true;
                }
            }
            if (_weapoonEnabled == false)
            {
                var _slot = _slotPanel.transform.GetChild(3);//номер последнего слота
                var _slotInfo = _slot.GetComponent<slotInfo>();
                var _pistolObj = GameObject.Find("dataSave").transform.GetChild(1).GetComponent<itemInfo>().item;
                _slot.GetChild(0).GetComponent<Image>().sprite = _pistolObj.Icon;
                var _image = _slot.GetChild(0).GetComponent<Image>();
                var _tempColor = _image.color;
                _tempColor.a = 1f;
                _image.color = _tempColor;//поставили нужную иконку                    
                _slotInfo._itemIndex = _pistolObj.id;
                _slotInfo._count = 1;
                _slotInfo._maxCount = _pistolObj.maxCount;
                _slotInfo._full = true;
                _slotInfo._rashodnik = false;
                _slotInfo._gameItem = true;
                _slotInfo._typeWeapoon = _pistolObj._typeWeapoon;
                _slotInfo._heel = _pistolObj._heel;
                _slotInfo._prefabForPlayer = _pistolObj.prefabforPlayer;
                _slotInfo._prefabForLocation = _pistolObj.prefabforLocation;
            }
            //при вовторном заходе снова выдовать пистолет
            _weapoonEnabled = false;
        }
    }
}
