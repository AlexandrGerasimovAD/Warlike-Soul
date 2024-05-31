using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapThorns : MonoBehaviour
{
    private GameObject _player;
    private GameObject _hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _hpSlider = GameObject.Find("playerHpSlider");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
          //  _hpSlider.GetComponent<HpSlider>()._hpCount -= 100;
            _hpSlider.GetComponent<HpSlider>().addHp(-100);
        }
    }
}
