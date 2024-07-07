using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
   public void OpenWinPanel()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("textCoinCountWin").GetComponent<TMP_Text>().text =
            GameObject.Find("AbsManager").GetComponent<RewardCountManager>()._coinCount.ToString();
        var _rewardCount = GameObject.Find("AbsManager").GetComponent<RewardCountManager>()._coinCount * 2;
        GameObject.Find("textCoinCountRewardWin").GetComponent<TMP_Text>().text = _rewardCount.ToString();          
    }
    public void ClosedWinPanel()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("AbsManager").GetComponent<RewardCountManager>()._coinCount = 0;
    }
}
