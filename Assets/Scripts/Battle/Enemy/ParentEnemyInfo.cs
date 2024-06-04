using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Name", menuName = "CreateEnemy/NewEnemy")]
public class ParentEnemyInfo : ScriptableObject
{
    public float _minDistance;
    public float _speed;
    public float _deleyAttack;
    public float _deleyActivDomageObj;
    public float _deleyDeActivDomageObj;
    public int _domage;
    public int _hp;
}
