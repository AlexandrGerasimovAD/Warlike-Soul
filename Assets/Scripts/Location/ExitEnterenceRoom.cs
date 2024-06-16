using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEnterenceRoom : MonoBehaviour
{
    public List<GameObject> roomsList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        object[] giveEnemy = Resources.LoadAll<GameObject>("bigRooms");
        foreach (GameObject giveEnemyObject in giveEnemy)
        {
            GameObject listObject = (GameObject)giveEnemyObject;
            roomsList.Add(listObject);
        }
        int enemiIndex = UnityEngine.Random.Range(0, roomsList.Count);
        GameObject room = roomsList[enemiIndex];
        var _room = Instantiate(room);
        _room.transform.SetParent(transform.parent.parent);
        _room.transform.localPosition = new Vector3(transform.localPosition.x-6, transform.localPosition.y
         , transform.localPosition.z+90);
        Destroy(gameObject);
    }

   
}
