using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDevil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("openBomb", 3);
        Destroy(gameObject, 4.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void openBomb()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
