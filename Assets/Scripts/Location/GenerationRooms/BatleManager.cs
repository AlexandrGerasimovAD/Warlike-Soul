using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatleManager : MonoBehaviour
{
    public Transform parent;
    public void voidUnBlocking()
    {
        Invoke("destroyBlocking", 1f);
        Invoke("destroyBlocking", 2f);
        Invoke("destroyBlocking", 3f);
    }
    private void destroyBlocking()
    {
        var _enemyCount = 0;
        for(int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).CompareTag("MainEnemy"))
            {
                _enemyCount++;
            }
        }
        if (_enemyCount == 0)
        {
            for(int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).CompareTag("blockWall"))
                {
                    Destroy(parent.GetChild(i).gameObject);
                }
            }
        }
    }
}
