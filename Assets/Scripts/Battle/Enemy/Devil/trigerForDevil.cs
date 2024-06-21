using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigerForDevil : MonoBehaviour
{
    public GameObject _devil;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _devil.GetComponent<DevilBattle>()._active = true;
            _devil.GetComponent<DevilBattle>()._resiveDomage = true;
        }
    }

}
