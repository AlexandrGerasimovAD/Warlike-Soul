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
        if (_hpCount + _countAddHp > 1000)//если хил превышает макс запас здоровья
        {
            _hpCount = 1000;
            _exception = true;
        }
        if (_hpCount + _countAddHp < 0)//если урон превышает минимальный запас здоровья
        {
            _hpCount = 0;
            _exception = true;
        }
        if (_exception == false)
        {
            _hpCount += _countAddHp;
        }
        if (_countAddHp > 0)//если больше 0 то это хил
        {
            transform.localScale = new Vector2(transform.localScale.x + ((1000 - _hpCount) / 5000), transform.localScale.y);
            transform.position = new Vector2(transform.position.x + 20, transform.position.y);
        }
        else//если меньше 0 то это урон
        {
            transform.localScale = new Vector2(transform.localScale.x - ((1000 - _hpCount) / 5000), transform.localScale.y);
            transform.position = new Vector2(transform.position.x - 20, transform.position.y);
        }
      //  if (_hpCount > 0)
      //  {
      //      transform.localScale = new Vector2(transform.localScale.x - ((1000 - _hpCount) / 5000), transform.localScale.y);
       //     transform.position = new Vector2(transform.position.x - 20, transform.position.y);
      //  }
            if (_hpCount < 0 || _hpCount == 0)//обработка отрицательного или нулевого значения
            {
               gameObject.SetActive(false);
            }
            else
            {
               gameObject.SetActive(true);
            }
    }
}
