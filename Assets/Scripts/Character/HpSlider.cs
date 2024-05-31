using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSlider : MonoBehaviour
{
    public float _hpCount=1000;
    public float _addCountHp;
    private bool _exception=false;
    void Start()
    {
        
    }
   
    public void addHp(float _countAddHp)
    {
        _exception = false;
        if (_hpCount + _countAddHp > 1000)//���� ��� ��������� ���� ����� ��������
        {
            _hpCount = 1000;
            _exception = true;
        }
        if (_hpCount + _countAddHp < 0)//���� ���� ��������� ����������� ����� ��������
        {
            _hpCount = 0;
            _exception = true;
        }
        if (_exception == false)
        {
            _hpCount += _countAddHp;
        }
        if (_countAddHp > 0)//���� ������ 0 �� ��� ���
        {
            transform.localScale = new Vector2(transform.localScale.x + ((1000 - _hpCount) / 5000), transform.localScale.y);
            transform.position = new Vector2(transform.position.x + 20, transform.position.y);
        }
        else//���� ������ 0 �� ��� ����
        {
            transform.localScale = new Vector2(transform.localScale.x - ((1000 - _hpCount) / 5000), transform.localScale.y);
            transform.position = new Vector2(transform.position.x - 20, transform.position.y);
        }
      //  if (_hpCount > 0)
      //  {
      //      transform.localScale = new Vector2(transform.localScale.x - ((1000 - _hpCount) / 5000), transform.localScale.y);
       //     transform.position = new Vector2(transform.position.x - 20, transform.position.y);
      //  }
            if (_hpCount < 0 || _hpCount == 0)//��������� �������������� ��� �������� ��������
            {
               gameObject.SetActive(false);
            }
            else
            {
               gameObject.SetActive(true);
            }
    }
}
