using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelCoinAdsPanel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("coinForAdsPanel").transform.GetChild(0).gameObject.SetActive(false);
    }
}
