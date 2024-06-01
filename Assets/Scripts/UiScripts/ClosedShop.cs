using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosedShop : MonoBehaviour,IPointerClickHandler
{
   
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("shop").transform.GetChild(0).gameObject.SetActive(false);
    }

}
