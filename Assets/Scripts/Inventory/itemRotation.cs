using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRotation : MonoBehaviour
{
    private float _rotation;
    private float _scale;
    private float _offScale;
    private bool _upScale = false;
    private void Start()
    {
        _scale = transform.localScale.x;
        _offScale = transform.localScale.x / 1.5f;
    }
    private void FixedUpdate()
    {      
        _rotation += 1.5f;
        gameObject.transform.localRotation = Quaternion.Euler(0, 0,
        transform.localRotation.z + _rotation);
        if (transform.localScale.x > _offScale&&_upScale==true)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y,
            transform.localScale.z - 0.005f);
            if (transform.localScale.x < _offScale)
            {
                _upScale = false;
            }
        }
        else
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.005f, transform.localScale.y,
            transform.localScale.z + 0.005f);
            if (transform.localScale.x > _scale)
            {
                _upScale = true;
            }
        }
    }
}
