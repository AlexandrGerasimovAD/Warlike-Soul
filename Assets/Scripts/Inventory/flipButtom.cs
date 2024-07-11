using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class flipButtom : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    private GameObject _player;
    private GameObject _itemForLocation;
    public itemInfo _item;
    public bool _isClick;
    private Animator _animator;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = gameObject.GetComponent<Animator>();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _isClick = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isClick = true;
        if (_item != null)
        {
            //выброс предмета перед заменой
            _itemForLocation= gameObject.transform.parent.GetComponent<slotInfo>()._prefabForLocation;
            if (_itemForLocation != null) { var _drop = Instantiate(_itemForLocation);
                _drop.transform.localPosition = new Vector3(_player.transform.localPosition.x + 1,
 _player.transform.localPosition.y + (float)2.5, _player.transform.localPosition.z + 1);
            }
           // _drop.transform.SetParent(_player.transform.parent);
            //замена предмета в слоте
            var _slotParent = gameObject.transform.parent.GetComponent<slotInfo>();
            _slotParent._count = _item.item.countItem;
            _slotParent._full = false;
            _slotParent._itemIndex = _item.item.id;
            _slotParent._maxCount = _item.item.maxCount;
            _slotParent._typeWeapoon = _item.item._typeWeapoon;
            _slotParent._prefabForPlayer = _item.item.prefabforPlayer;
            _slotParent._prefabForLocation = _item.item.prefabforLocation;
            var _icon = gameObject.transform.parent.GetChild(0);
            _icon.GetComponent<Image>().sprite = _item.item.Icon;
            var _textCount = gameObject.transform.parent.GetChild(1);
            _textCount.GetComponent<TMP_Text>().text = _item.item.countItem.ToString();

        }       
    }
    private void Update()
    {
        if (_item == null)
        {
            var _image1 = gameObject.GetComponent<Image>();           
            var _tempColor = _image1.color;
            _tempColor.a = 0f;
            _image1.color = _tempColor;
            _animator.SetBool("animFlip", false);
        }
        else
        {
            var _image1 = gameObject.GetComponent<Image>();
            var _tempColor = _image1.color;
            _tempColor.a = 1f;
            _image1.color = _tempColor;
            _animator.SetBool("animFlip", true);
        }
    }
}
