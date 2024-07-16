using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    public float _hpCount=1000;
    public float _addCountHp;
    private bool _exception=false;
    private Slider _slider;
    private GameObject _hand;
    private GameObject _player;
    private GameObject _base;
    private GameObject _cam;
    private string _name;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _base = GameObject.Find("mainBase");
        _cam = GameObject.Find("Main Camera");
        _hand = GameObject.Find("handCharacter");
        _slider = gameObject.GetComponent<Slider>();                           
    }
   
    public void addHp(float _countAddHp)
    {
        _exception = false;
        if (_hpCount + _countAddHp > 1000)//если хил превышает макс запас здоровья
        {
            _hpCount = 1000;
            _slider.value = 1;
            _exception = true;
        }
        if (_hpCount + _countAddHp < 0)//если урон превышает минимальный запас здоровья
        {
            _hpCount = 0;
            _exception = true;
            _slider.value = 0;
            CharacterDie();
        }
        if (_exception == false)
        {
            _hpCount += _countAddHp;
        }
        if (_countAddHp > 0)//если больше 0 то это хил
        {
            _slider.value +=_countAddHp/1000;
           // transform.localScale = new Vector2(transform.localScale.x + ((1000 - _hpCount) / 5000), transform.localScale.y);
          //  transform.position = new Vector2(transform.position.x + 20+(_hpCount/100), transform.position.y);
        }
        else//если меньше 0 то это урон
        {
            _slider.value += _countAddHp / 1000;
        }
      //  if (_hpCount > 0)
      //  {
      //      transform.localScale = new Vector2(transform.localScale.x - ((1000 - _hpCount) / 5000), transform.localScale.y);
       //     transform.position = new Vector2(transform.position.x - 20, transform.position.y);
      //  }
            
    }
    private void CharacterDie()
    {
        var _slotPanel = GameObject.Find("InventoryPanel");
        for(int i = 0; i < _slotPanel.transform.childCount; i++)
        {
            var _slot = _slotPanel.transform.GetChild(i);
            var _slotInfo = _slot.GetComponent<slotInfo>();
            //очистка иконки и кол во          
            var _imageGo = _slot.transform.GetChild(0).GetComponent<Image>();
            var _tempColorGo = _imageGo.color;
            _tempColorGo.a = 0f;
            _imageGo.color = _tempColorGo;//поставили нужную иконку
            _slot.transform.GetChild(1).GetComponent<TMP_Text>().text = null;//очистил текст кол-во
            _slotInfo._itemIndex = 0;
            _slotInfo._count = 0;
            _slotInfo._maxCount = 0;
            _slotInfo._full = false;
            _slotInfo._rashodnik = false;
            _slotInfo._gameItem = false;
            _slotInfo._typeWeapoon = 0;
            _slotInfo._heel = 0;
            _slotInfo._prefabForPlayer = null;
            _slotInfo._prefabForLocation = null;
            if (_hand.transform.childCount != 0)
            {
                var _animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
                Destroy(_hand.transform.GetChild(0).gameObject);
                _animator.SetInteger("typeWeapoon", 0);
            }           
        }
        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
        var _name = _player.transform.parent.GetComponent<StartGenerationRooms>()._nameNext;
        var _batleLoc = _player.transform.parent;
        _player.GetComponent<CharacterController>().enabled = false;
        _base.transform.GetChild(0).gameObject.SetActive(true);
        _player.transform.SetParent(_base.transform);
        _cam.transform.SetParent(_base.transform);
        var _point = GameObject.Find("SpawnPoint").transform.localPosition;//для удобства работы с координатами 
        _player.transform.localPosition = new Vector3(_point.x, _point.y, _point.z);
        _player.GetComponent<CharacterController>().enabled = true;
        _batleLoc.gameObject.SetActive(false);
        if (_name == "BatleLevel2")
        {
            var _location = GameObject.Find("BatleReserv").transform.GetChild(0).gameObject;
            var _spawn = Instantiate(_location);
            _spawn.transform.SetParent(_batleLoc.parent);
            _spawn.transform.localPosition = _batleLoc.localPosition;
            Destroy(_batleLoc.gameObject);
            GameObject.Find("WinMainPanel").GetComponent<WinPanel>().OpenWinPanel();
        }
        if (_name == "BatleLevel3")
        {
            var _location = GameObject.Find("BatleReserv").transform.GetChild(1).gameObject;
            var _spawn = Instantiate(_location);
            _spawn.transform.SetParent(_batleLoc.parent);
            _spawn.transform.localPosition = _batleLoc.localPosition;
            Destroy(_batleLoc.gameObject);
            GameObject.Find("WinMainPanel").GetComponent<WinPanel>().OpenWinPanel();
        }
        if (_name == "Boss")
        {
            var _location = GameObject.Find("BatleReserv").transform.GetChild(2).gameObject;
            var _spawn = Instantiate(_location);
            _spawn.transform.SetParent(_batleLoc.parent);
            _spawn.transform.localPosition = _batleLoc.localPosition;
            Destroy(_batleLoc.gameObject);
            GameObject.Find("WinMainPanel").GetComponent<WinPanel>().OpenWinPanel();
        }
        if (_name == "Base")
        {
            var _location = GameObject.Find("BatleReserv").transform.GetChild(3).gameObject;
            var _spawn = Instantiate(_location);
            _spawn.transform.SetParent(_batleLoc.parent);
            _spawn.transform.localPosition = _batleLoc.localPosition;
            Destroy(_batleLoc.gameObject);
            GameObject.Find("WinMainPanel").GetComponent<WinPanel>().OpenWinPanel();
        }
        Invoke("rewardHp", 1);
    }
    public void rewardHp()
    {
        _slider.value = 1;
        _hpCount = 1000;
    }
}
