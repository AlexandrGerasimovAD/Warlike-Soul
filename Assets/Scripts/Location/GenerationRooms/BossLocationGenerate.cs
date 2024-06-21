using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLocationGenerate : MonoBehaviour
{
    public List<GameObject> roomsList = new List<GameObject>();
    void Start()
    {
        object[] giveEnemy = Resources.LoadAll<GameObject>("BossRooms");
        foreach (GameObject giveEnemyObject in giveEnemy)
        {
            GameObject listObject = (GameObject)giveEnemyObject;
            roomsList.Add(listObject);
        }
        int enemiIndex = UnityEngine.Random.Range(0, roomsList.Count);
        GameObject room = roomsList[enemiIndex];
        var _room = Instantiate(room);
        _room.transform.SetParent(transform.parent.parent);
        _room.transform.localPosition = new Vector3(transform.localPosition.x - (float)36.5, transform.localPosition.y
         , transform.localPosition.z + 90);
        Destroy(gameObject);
    }
}
