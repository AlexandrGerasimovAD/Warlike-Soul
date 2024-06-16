using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEnterence : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            var _block = transform.GetChild(0);
            _block.transform.localPosition = new Vector3(_block.transform.localPosition.x, _block.transform.localPosition.y,
            _block.transform.localPosition.z - (float)0.04);
            _block.transform.SetParent(transform.parent);          
            Destroy(gameObject);
        }
    }
}
