using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private GameObject _player;
    private GameObject _shopPanel;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _shopPanel = GameObject.Find("shop").transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _shopPanel.SetActive(false);
        }
    }
}
