using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosedShop : MonoBehaviour,IPointerClickHandler
{
    private GameObject _shopPanel;
    private void Start()
    {
        _shopPanel = GameObject.Find("GoblinShop");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      
        _shopPanel.SetActive(false);
    }

}
