using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosedWinPanel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("WinMainPanel").GetComponent<WinPanel>().ClosedWinPanel();
    }
}