using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    private int _speed = 65;
    private GameObject _collizionEffect;
    public float _domage;
    // Start is called before the first frame update
    void Start()
    {
        _collizionEffect = gameObject.transform.GetChild(0).gameObject;
        Destroy(gameObject, 2);
        GameObject.Find("standartShotSound").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (transform.up * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle")|| other.gameObject.CompareTag("enemy"))
        {
           _collizionEffect.SetActive(true);
           _collizionEffect.transform.SetParent(other.transform);
           Destroy(gameObject);
        }
    }
  
}
