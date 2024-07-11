using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;

    public class RewardAdsControl : MonoBehaviour
    {
    private String message = "";

    private RewardedAdLoader rewardedAdLoader;
    private RewardedAd rewardedAd;
    private void Awake()
    {
        SetupLoader();
        RequestRewardAd();
    }

    private void SetupLoader()
    {
        rewardedAdLoader = new RewardedAdLoader();
        rewardedAdLoader.OnAdLoaded +=HandleAdLoader;
        rewardedAdLoader.OnAdFailedToLoad +=HandleAdFailedLoad;
    }
    private void RequestRewardAd()
    {
        string adUnitId = "R-M-9985864-1";//индификатор рекламного блока на сайте –—я
        AdRequestConfiguration adRequestConfiguration = new AdRequestConfiguration.Builder(adUnitId).Build();
        rewardedAdLoader.LoadAd(adRequestConfiguration);
    }
    public void ShowRewardAd()//показ рекламы вызывать эту функцию
    {
        if (rewardedAd != null)
        {
            rewardedAd.Show();
        }
    }
    public void DestroyRewerdedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
    }
    public void HandleAdLoader(object sender, RewardedAdLoadedEventArgs args)
    {
        rewardedAd = args.RewardedAd;
        Debug.Log(message: ">>> YandexAbs OnAdLoaded");
        rewardedAd.OnAdClicked += HandleAdClicked;
        rewardedAd.OnAdShown += HandleAdShow;
        rewardedAd.OnAdFailedToShow += HandleAdFailedToShow;
        rewardedAd.OnAdImpression += HandleAdImpression;
        rewardedAd.OnAdDismissed += HandleAdDismissed;
        rewardedAd.OnRewarded += HandleAdRewarded;
    }
    public void HandleAdFailedLoad(object sender,AdFailedToLoadEventArgs args)
    {
        Debug.Log(message: ">>> YandexAbs OnAdFailedLoad");
    }
    //обработчики ниже и событи€ при которых они срабатывают
    public void HandleAdClicked(object sender,EventArgs args) //в момент клика по рекламе
    {
        Debug.Log(message: ">>> YandexAbs OnAdClicked");
    }
    public void HandleAdShow(object sender, EventArgs args)//когда начинаетс€ показ рекламы
    {
        Debug.Log(message: ">>> YandexAbs OnAdShow");
    }
    public void HandleAdFailedToShow(object sender, AdFailureEventArgs args)//когда показ не состо€лс€ из за ошибки
    {
        Debug.Log(message: ">>> YandexAbs OnAdFailedToShow");
        DestroyRewerdedAd();
        RequestRewardAd();
    }
    public void HandleAdImpression(object sender, ImpressionData impressionData)//в момент регистрации показа
    {
        Debug.Log(message: ">>> YandexAbs OnAdImpression"+impressionData.rawData);
    }
    public void HandleAdDismissed(object sender, EventArgs args)//в момент закрыти€ пользователем рекламного обь€влени€
    {
        Debug.Log(message: ">>> YandexAbs OnAdDismissed");
        DestroyRewerdedAd();
        RequestRewardAd();
    }
    public void HandleAdRewarded(object sender, Reward args)//в момент начислени€ награды
    {
        Debug.Log(message: ">>> YandexAbs OnAdRewarded");
        var _rewardCount = GameObject.Find("AbsManager").GetComponent<RewardCountManager>()._coinCount * 2;
        var _getCoin = PlayerPrefs.GetInt("mainCoinSave");
        PlayerPrefs.SetInt("mainCoinSave", _getCoin + _rewardCount);
        var _pushCoin = PlayerPrefs.GetInt("mainCoinSave");
        GameObject.Find("textCoin").GetComponent<TMP_Text>().text = _pushCoin.ToString();
    }

}

