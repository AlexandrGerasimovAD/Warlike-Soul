using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    public float _hpCount=1000;
    public float _addCountHp;
    private bool _exception=false;
    private Slider _slider;
    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
    }
   
    public void addHp(float _countAddHp)
    {
        _exception = false;
        if (_hpCount + _countAddHp > 1000)//���� ��� ��������� ���� ����� ��������
        {
            _hpCount = 1000;
            _slider.value = 1;
            _exception = true;
        }
        if (_hpCount + _countAddHp < 0)//���� ���� ��������� ����������� ����� ��������
        {
            _hpCount = 0;
            _exception = true;
            _slider.value = 0;
        }
        if (_exception == false)
        {
            _hpCount += _countAddHp;
        }
        if (_countAddHp > 0)//���� ������ 0 �� ��� ���
        {
            _slider.value +=_countAddHp/1000;
           // transform.localScale = new Vector2(transform.localScale.x + ((1000 - _hpCount) / 5000), transform.localScale.y);
          //  transform.position = new Vector2(transform.position.x + 20+(_hpCount/100), transform.position.y);
        }
        else//���� ������ 0 �� ��� ����
        {
            _slider.value += _countAddHp / 1000;
        }
      //  if (_hpCount > 0)
      //  {
      //      transform.localScale = new Vector2(transform.localScale.x - ((1000 - _hpCount) / 5000), transform.localScale.y);
       //     transform.position = new Vector2(transform.position.x - 20, transform.position.y);
      //  }
            
    }
}
