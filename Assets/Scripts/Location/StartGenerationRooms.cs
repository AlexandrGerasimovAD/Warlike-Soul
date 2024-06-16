using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGenerationRooms : MonoBehaviour
{
    public GameObject EnterenceRoom;
    public bool _generateRoom = true;
    public int _maxCountRoom;
    public int _countRoom;
    // Start is called before the first frame update
    void Start()
    {
        var _enerence = Instantiate(EnterenceRoom);
        _enerence.transform.SetParent(transform);
        _enerence.transform.localPosition = transform.localPosition;
    }

}
