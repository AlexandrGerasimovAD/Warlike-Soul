using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraRunToPlayer : MonoBehaviour
{
    //private LayerMask _layerMask;
    private Transform _target;
    private float _maxDistance;
    public Vector3 _localPosition;
    private Vector3 _position
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }
    //метод перемещения камеры вслед за игроком,камера пускает луч проверяет нет ли между игроком и ней препядствий
    //если есть то перемещаеться ближе к игроку 
    void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
        _localPosition = _target.InverseTransformPoint(_position);
        _maxDistance = Vector3.Distance(_position, _target.position);
    }
    private void LateUpdate()
    {
        _position = _target.TransformPoint(_localPosition);
        ObsteclesReact();
        _localPosition = _target.InverseTransformPoint(_position);
    }
    private void ObsteclesReact()
    {
        var _distance = Vector3.Distance(_position, _target.position);
        RaycastHit _hit;
        if (Physics.Raycast(_target.position, transform.position - _target.position, out _hit, _maxDistance))//запятая маска слой
        {
            _position = _hit.point;
        }
        else if (_distance < _maxDistance && !Physics.Raycast(_position, -transform.forward, .1f))//запятая маска слой
        {
            _position -= transform.forward * .05f;
        }    
    }
}
