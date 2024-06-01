using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosedChest : MonoBehaviour,IPointerClickHandler
{
    private GameObject _chestPanel;

   
    void Start()
    {
        _chestPanel = GameObject.Find("mainChestPanel");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _chestPanel.SetActive(false);
        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
        GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveChest();
    }
}
