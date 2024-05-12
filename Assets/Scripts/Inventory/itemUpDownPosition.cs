using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class itemUpDownPosition : MonoBehaviour
{
    private float _position;
    private float _offPosition;
    private bool _upTransform = true;
    private GameObject _player;
    private TMP_Text _coinText;
    private int _coinInt;
    // Start is called before the first frame update
    void Start()
    {
        _position = gameObject.transform.localPosition.y *1.2f;
        _offPosition = gameObject.transform.localPosition.y / 1.2f;
        _player = GameObject.FindGameObjectWithTag("Player");
        _coinText = GameObject.Find("textCoin").GetComponent<TMP_Text>();
        _coinInt = GameObject.Find("coinPanel").GetComponent<coinsForCanvas>()._coins;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_upTransform == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.02f,
            transform.localPosition.z);
            if (transform.localPosition.y > _position)
            {
                _upTransform = false;
            }

        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.02f,
            transform.localPosition.z);
            if (transform.localPosition.y < _offPosition)
            {
                _upTransform = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            var _getCoin = PlayerPrefs.GetInt("mainCoinSave");
            PlayerPrefs.SetInt("mainCoinSave", _getCoin + 50);
            var _pushCoin= PlayerPrefs.GetInt("mainCoinSave");
            _coinText.text=_pushCoin.ToString();
           // _coinText.text = _coinInt.ToString();
            Destroy(gameObject);
        }
    }
}
