using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinForAds : MonoBehaviour
{
    private float _position;
    private float _offPosition;
    private bool _upTransform = true;
    private GameObject _player;
    private TMP_Text _coinText;
    public int _coinCount;
    // Start is called before the first frame update
    void Start()
    {
        _position = gameObject.transform.position.y + 1.1f;
        _offPosition = gameObject.transform.position.y - 1.1f;
        _player = GameObject.FindGameObjectWithTag("Player");
        _coinText = GameObject.Find("textCoin").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_upTransform == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f,
            transform.position.z);
            if (transform.position.y > _position)
            {
                _upTransform = false;
            }
        }
        if (_upTransform == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f,
            transform.position.z);
            if (transform.position.y < _offPosition)
            {
                _upTransform = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            GameObject.Find("coinForAdsPanel").transform.GetChild(0).gameObject.SetActive(true);            
        }
    }
}
