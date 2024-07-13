using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class startAdsForBaseReward : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("AbsManager").GetComponent<RewardCountManager>()._coinCount = 125;
        GameObject.Find("AbsManager").GetComponent<RewardAdsControl>().ShowRewardAd();
    }
}
