using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rewardCoinButtom : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("AbsManager").GetComponent<RewardAdsControl>().ShowRewardAd();
        GameObject.Find("WinMainPanel").GetComponent<WinPanel>().ClosedWinPanel();
    }
}
