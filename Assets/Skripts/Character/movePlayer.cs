using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private bl_Joystick _joystick;
    // Start is called before the first frame update
    void Start()
    {
        _joystick = GameObject.Find("Joystick").GetComponent<bl_Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_joystick.Horizontal * 2 * Time.deltaTime, 0, _joystick.Vertical * 2 * Time.deltaTime);
    }
}
