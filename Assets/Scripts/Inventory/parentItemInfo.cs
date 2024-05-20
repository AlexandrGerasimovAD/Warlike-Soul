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
    public int _typeWeapoon;//0 руки 1 меч 2 пистолет 3 автомат
    public int _heel;
    public int countItem;
    public int maxCount;
    public float damage;
    public double delayShot;
    [Multiline(5)]
    public string descriptionItem;
    public GameObject prefabforPlayer;
    public GameObject prefabforLocation;
    public Sprite Icon;
}
