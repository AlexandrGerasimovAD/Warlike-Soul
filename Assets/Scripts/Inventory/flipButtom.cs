using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class flipButtom : MonoBehaviour,IPointerClickHandler,IPointerUpHandler,IPointerDownHandler
{
    private GameObject _player;
    public itemInfo _item;
    public bool _isClick;
    private Animator _animator;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = gameObject.GetComponent<Animator>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
          
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
            var _slotParent = gameObject.transform.parent.GetComponent<slotInfo>();
            _slotParent._count = _item.item.countItem;
            _slotParent._full = false;
            _slotParent._itemIndex = _item.item.id;
            _slotParent._maxCount = _item.item.maxCount;
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
