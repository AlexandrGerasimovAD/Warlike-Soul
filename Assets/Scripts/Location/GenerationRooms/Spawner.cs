using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<GameObject> enemyList = new List<GameObject>();
    private List<GameObject> pointList = new List<GameObject>();
    private GameObject _point;
    // Start is called before the first frame update
    void Start()
    {
        var _parent = transform.parent.parent;
        for (int i = 0; i < _parent.childCount; i++)
        {
            if (_parent.GetChild(i).CompareTag("walkPoint"))
            {
                pointList.Add(_parent.GetChild(i).gameObject);
            }
        }
        object[] giveEnemy = Resources.LoadAll<GameObject>("Enemys");
        foreach (GameObject giveEnemyObject in giveEnemy)
        {
            GameObject listObject = (GameObject)giveEnemyObject;
            enemyList.Add(listObject);
        }
        var _countEnemy = UnityEngine.Random.Range(transform.parent.parent.parent.GetComponent<StartGenerationRooms>()._minCountEnemy,
            transform.parent.parent.parent.GetComponent<StartGenerationRooms>()._countEnemy);
        for (int i = 0; i < _countEnemy; i++)
        {
            int enemiIndex = UnityEngine.Random.Range(0, enemyList.Count);
            GameObject enemy = enemyList[enemiIndex];
            var _enemy = Instantiate(enemy);
            _enemy.transform.SetParent(transform.parent.parent);
            _enemy.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,
                transform.localPosition.z);
            _point = pointList[UnityEngine.Random.Range(0, pointList.Count)];
            transform.localPosition = new Vector3(_point.transform.localPosition.x
                ,_point. transform.localPosition.y, _point.transform.localPosition.z);
        }       
    }
}
