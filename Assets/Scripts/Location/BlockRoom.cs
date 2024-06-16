using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            var _block = transform.GetChild(0);
            _block.transform.localPosition = new Vector3(_block.transform.localPosition.x, _block.transform.localPosition.y,
            _block.transform.localPosition.z - (float)0.04);
            _block.transform.SetParent(transform.parent);
            //�����1
                var _block1 = transform.GetChild(0);
                _block1.transform.localPosition = new Vector3(_block1.transform.localPosition.x, _block1.transform.localPosition.y,
                _block1.transform.localPosition.z - (float)0.04);
                _block1.transform.SetParent(transform.parent);
            //�����2
                var _block2 = transform.GetChild(0);
                _block2.transform.localPosition = new Vector3(_block2.transform.localPosition.x, _block2.transform.localPosition.y,
                _block2.transform.localPosition.z - (float)0.04);
                _block2.transform.SetParent(transform.parent);           
            //�����3
                var _block3 = transform.GetChild(0);
                _block3.transform.localPosition = new Vector3(_block3.transform.localPosition.x, _block3.transform.localPosition.y,
                _block3.transform.localPosition.z - (float)0.04);
                _block3.transform.SetParent(transform.parent);           
            //�����4
            Destroy(gameObject);
        }
    }
}
