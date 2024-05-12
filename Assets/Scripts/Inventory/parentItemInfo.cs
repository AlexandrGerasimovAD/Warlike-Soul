using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "Name", menuName = "CreateItem/NewItem")]
public class parentItemInfo : ScriptableObject
{
    public string nameItem;
    public int id;
    public int countItem;
    public int maxCount;
    public float damage;
    public double delayShot;
    [Multiline(5)]
    public string descriptionItem;
    public GameObject prefab;
    public Sprite Icon;
    public UnityEvent customEvent;
}
