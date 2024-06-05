using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResiveDomageMummy : MonoBehaviour
{
    public GameObject _hpSlider;
    private float _hp;
    private float _sliderHp = 1;
    public GameObject _dieEffect;

    // Start is called before the first frame update
    void Start()
    {
        _hp = gameObject.GetComponent<EnemyInfo>()._enemyInfo._hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playerDomage"))
        {
            domageForEnemySlider(other.gameObject.GetComponent<Patron>()._domage);
        }
    }
    private void domageForEnemySlider(float _domage)
    {
        if (_sliderHp - _domage / _hp < 0)
        {
            _hpSlider.transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
            _sliderHp = 0;
            _dieEffect.SetActive(true);
            _dieEffect.transform.SetParent(transform.parent.parent.parent);
            gameObject.transform.parent.GetComponent<TrigerForWalk>()._die = true;
            Destroy(gameObject.transform.parent.parent.gameObject);
        }
        else
        {
            gameObject.transform.parent.GetComponent<TrigerForWalk>()._resiveDomage = true;
            _hpSlider.gameObject.SetActive(true);
            _hpSlider.transform.localScale = new Vector3(_sliderHp - _domage / _hp, transform.localScale.y, transform.localScale.z);
            _sliderHp = _sliderHp - _domage / _hp;
        }
    }
}