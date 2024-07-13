using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
   private Vector3 _firstPoint;
   private Vector3 _secondPoint;
   private float _xAngle;
   public float _yAngle;
   private float _xAngleTemp;
   private float _yAngleTemp;
   public int _speedToX;
   public int _SpeedToY;
   public int _minBlockToY;
   public int _maxBlockToY;
    private GameObject _player;
    private Animator _animator;
    public float _ySecondValue=0;
    void Start()
    {
        _yAngle = transform.localRotation.eulerAngles.y;
        _player = GameObject.FindWithTag("Player");
        _animator = _player.GetComponent<Animator>();
        if (PlayerPrefs.GetInt("cameraSpeedX") != 0)
        {
            _speedToX = PlayerPrefs.GetInt("cameraSpeedX");
        } 
    }
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
         if (touch.position.x > Screen.width / 2 & touch.phase == TouchPhase.Began)
         {
         _firstPoint = touch.position;
         _xAngleTemp = _xAngle;
         _yAngleTemp = _yAngle;
         }
            if (touch.position.x > Screen.width / 2 & touch.phase == TouchPhase.Moved)
            {
                _secondPoint = touch.position;
                _xAngle = _xAngleTemp - (_secondPoint.y - _firstPoint.y) * _speedToX / Screen.height;
                _yAngle = _yAngleTemp + (_secondPoint.x - _firstPoint.x) * _SpeedToY / Screen.width;
               _player.transform.rotation = Quaternion.Euler(0, _yAngle, 0);//вращение персонажа за камерой 
                _xAngle = Mathf.Clamp(_xAngle, _minBlockToY, _maxBlockToY);//ограничение камеры ось мин и макс
                Camera.main.transform.rotation = Quaternion.Euler(_xAngle, _yAngle, 0);//вращение камеры
            }
        }
        if (_yAngle != _ySecondValue)//метод перешагивания при повороте камеры
        {
            if (_yAngle - _ySecondValue > 1)
            {
                _animator.SetBool("camRight", true);
                
            }
            if (_yAngle - _ySecondValue < -1)
            {
                
                _animator.SetBool("camLeft", true);
            }
        }
        else
        {
            _animator.SetBool("camLeft", false);
            _animator.SetBool("camRight", false);
        }
        _ySecondValue = _yAngle;

    }
}
