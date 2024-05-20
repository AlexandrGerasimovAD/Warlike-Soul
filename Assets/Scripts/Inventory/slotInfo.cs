using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slotInfo : MonoBehaviour,IPointerClickHandler
{
    public int _slotIndex;
    public int _itemIndex;
    public int _count;
    public int _maxCount;
    public bool _full;
    public bool _rashodnik;
    public bool _gameItem;
    public int _typeWeapoon;//0 ���� 1 ��� 2 �������� 3 �������
    public int _heel;
    public GameObject _prefabForPlayer;
    public GameObject _prefabForLocation;
    private GameObject _hand;
    private Animator _animator;
    private void Start()
    {
        _hand = GameObject.Find("handCharacter"); 
        _animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.GetComponent<slotInfo>()._rashodnik == true)
        {
            //��� ���������� ����������
        }
        if (gameObject.GetComponent<slotInfo>()._gameItem == true)
        {
            //����� ������� � ����
            if (_hand.transform.childCount != 0)
            {
               Destroy(_hand.transform.GetChild(0).gameObject);
            }           
            if (gameObject.GetComponent<slotInfo>()._typeWeapoon == 0)
            {
                //�������� �������� ��� �������
                _animator.SetInteger("typeWeapoon", 0);
            }
            if (gameObject.GetComponent<slotInfo>()._typeWeapoon == 1)
            {
                //�������� �������� ��� �����
                _animator.SetInteger("typeWeapoon", 1);
            }
            if (gameObject.GetComponent<slotInfo>()._typeWeapoon == 2)
            {
                //�������� �������� ��� ���������
                _animator.SetInteger("typeWeapoon", 2);
                var _spawn = Instantiate(gameObject.GetComponent<slotInfo>()._prefabForPlayer);
                _spawn.transform.SetParent(_hand.transform);
                _spawn.transform.localPosition = new Vector3(_hand.transform.localPosition.x, _hand.transform.localPosition.y,
                _hand.transform.localPosition.z);
                _spawn.transform.localRotation = Quaternion.Euler(110, 0, 90);
            }
            if (gameObject.GetComponent<slotInfo>()._typeWeapoon == 3)
            {
                //�������� �������� ��� ��������
                _animator.SetInteger("typeWeapoon", 3);
            }
        }
    }

}
