using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackObjDomage : MonoBehaviour
{
    private GameObject _playerHp;
    private GameObject _player;
    public int _domage;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHp = GameObject.Find("playerHpSlider");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (transform.forward * 20 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
           _playerHp.GetComponent<HpSlider>().addHp(-_domage);
        }
    }
}
