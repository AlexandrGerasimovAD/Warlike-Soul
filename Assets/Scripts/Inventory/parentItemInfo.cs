using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Name", menuName = "CreateItem/NewItem")]
public class parentItemInfo : ScriptableObject
{
    public string nameItem;
    public int id;
    public bool _rashodnik;
    public bool _gameItem;
    public int _typeWeapoon;//0 ���� 1 ��� 2 �������� 3 �������
    public int _heel;
    public int countItem;
    public int maxCount;
    public float damage;
    public float delayShot;
    public int _byCount;
    [Multiline(5)]
    public string descriptionItem;
    public GameObject prefabforPlayer;
    public GameObject prefabforLocation;
    public GameObject prefabShot;
    public Sprite Icon;
}
