using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGenerationRoom : MonoBehaviour
{
    public GameObject _pol;
    public GameObject _wall;
    public int _sizeX;
    public int _sizeY;
    // Start is called before the first frame update
    void Start()
    {
        var _position = gameObject.transform.localPosition;
        var _positionZ = gameObject.transform.localPosition;
        _positionZ = new Vector3(_positionZ.x, _positionZ.y, _positionZ.z + 6);
        for (int i = 0; i <= _sizeX; i++)
        {
            if (i == 0)
            {
                var wall = Instantiate(_wall);
                wall.transform.localPosition = new Vector3(_position.x-3,_position.y+5,_position.z);
                wall.transform.SetParent(gameObject.transform);
                var wall1 = Instantiate(_wall);
                wall1.transform.localPosition = new Vector3(_position.x - 3, _position.y + (float)10.4, _position.z);
                wall1.transform.SetParent(gameObject.transform);
            }
            if (i == _sizeX)
            {
                var wall = Instantiate(_wall);
                wall.transform.localPosition = new Vector3(_position.x + 3, _position.y + 5, _position.z);
                wall.transform.SetParent(gameObject.transform);
                var wall1 = Instantiate(_wall);
                wall1.transform.localPosition = new Vector3(_position.x + 3, _position.y+(float)10.4, _position.z);
                wall1.transform.SetParent(gameObject.transform);
            }
            var pol = Instantiate(_pol);
            pol.transform.localPosition = _position;
            pol.transform.SetParent(gameObject.transform);
            var pol1 = Instantiate(_pol);
            pol1.transform.localPosition = new Vector3(_position.x,_position.y+(float)10.5,_position.z);
            pol1.transform.SetParent(gameObject.transform);
            var wall2 = Instantiate(_wall);
            wall2.transform.localPosition = new Vector3(_position.x , _position.y + 5, _position.z-3);
            wall2.transform.SetParent(gameObject.transform);
            wall2.transform.localRotation = Quaternion.Euler(180,0, 0);
            var wall3 = Instantiate(_wall);
            wall3.transform.localPosition = new Vector3(_position.x, _position.y + (float)10.4, _position.z-3);
            wall3.transform.SetParent(gameObject.transform);
            wall3.transform.localRotation = Quaternion.Euler(180, 0, 0);
            _position = new Vector3(_position.x + 6, _position.y, _position.z);
            for (int j = 0; j <= _sizeY; j++)
            {
                if (j == _sizeY)
                {
                    var wall = Instantiate(_wall);
                    wall.transform.localPosition = new Vector3(_positionZ.x, _positionZ.y + 5, _positionZ.z+3);
                    wall.transform.SetParent(gameObject.transform);
                    wall.transform.localRotation = Quaternion.Euler(180, 0, 0);
                    var wall1 = Instantiate(_wall);
                    wall1.transform.localPosition = new Vector3(_positionZ.x, _positionZ.y + (float)10.4, _positionZ.z + 3);
                    wall1.transform.SetParent(gameObject.transform);
                    wall1.transform.localRotation = Quaternion.Euler(180, 0, 0);
                }
                if (i==0)
                {
                    var wall = Instantiate(_wall);
                    wall.transform.localPosition = new Vector3(_positionZ.x-3, _positionZ.y + 5, _positionZ.z);
                    wall.transform.SetParent(gameObject.transform);
                    var wall1 = Instantiate(_wall);
                    wall1.transform.localPosition = new Vector3(_positionZ.x-3, _positionZ.y + (float)10.4, _positionZ.z);
                    wall1.transform.SetParent(gameObject.transform);
                }
                if (i == _sizeX)
                {
                    var wall = Instantiate(_wall);
                    wall.transform.localPosition = new Vector3(_positionZ.x + 3, _positionZ.y + 5, _positionZ.z);
                    wall.transform.SetParent(gameObject.transform);
                    var wall1 = Instantiate(_wall);
                    wall1.transform.localPosition = new Vector3(_positionZ.x + 3, _positionZ.y + (float)10.4, _positionZ.z);
                    wall1.transform.SetParent(gameObject.transform);
                }

                var polY = Instantiate(_pol);
                polY.transform.localPosition =_positionZ;
                polY.transform.SetParent(gameObject.transform);
                var pol2 = Instantiate(_pol);
                pol2.transform.localPosition = new Vector3(_positionZ.x, _positionZ.y + (float)10.5, _positionZ.z);
                pol2.transform.SetParent(gameObject.transform);
                _positionZ = new Vector3(_positionZ.x, _positionZ.y, _positionZ.z+6);
                if (j == _sizeY)
                {
                    _positionZ = new Vector3(_position.x, _position.y, _position.z + 6);
                }
            }
            
        } 
    }
}
