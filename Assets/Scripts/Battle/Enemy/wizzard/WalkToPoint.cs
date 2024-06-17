using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPoint : MonoBehaviour
{
    public bool _walkToPoin=true;
    private List<GameObject> pointList = new List<GameObject>();
    private float _speed;
    private bool _pointGive=true;
    private GameObject _point;
    void Start()
    {
        _speed = transform.GetChild(0).GetComponent<trigerForWalkWizzard>()._speed;
        var _parent = transform.parent;
        for(int i = 0; i < _parent.childCount; i++)
        {
            if (_parent.GetChild(i).CompareTag("walkPoint"))
            {
                pointList.Add(_parent.GetChild(i).gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (_pointGive == true)
        {
            _point = pointList[UnityEngine.Random.Range(0, pointList.Count)];
            _pointGive = false;
        }      
        if (transform.position.x == _point.transform.position.x||transform.position.z==_point.transform.position.z)
        {
            _pointGive = true;
        }
        if (_walkToPoin == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point.transform.position, 0.042f);
            transform.LookAt(_point.transform);
        }
    }
}
