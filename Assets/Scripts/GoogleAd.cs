using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class GoogleAd : MonoBehaviour
{
    private RewardedAd rewardedAd;
    string adUnitId;

    UIManager uiManager;


    public void Start()
    {
        //MobileAds.Initialize("ca-app-pub-1297276020699326~8294869285");

        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(HandleInitCompleteAction);

        uiManager = FindObjectOfType<UIManager>();

    }
    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        Debug.Log("Initialization complete.");

        // Callbacks from GoogleMobileAds are not guaranteed to be called on
        // the main thread.
        // In this example we use MobileAdsEventExecutor to schedule these calls on
        // the next Update() loop.
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            Debug.Log("Initialization Complatie");
            RequestInterstitial();
        });
    }

    private void RequestInterstitial()
    {
//#if UNITY_ANDROID
//        adUnitId = "ca-app-pub-3940256099942544/5224354917";
//#else
//            adUnitId = "unexpected_platform";
//#endif

//        this.rewardedAd = new RewardedAd(adUnitId);

//        //// 광고 로드가 완료되면 호출
//        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
//        //// 광고 로드가 실패했을 때 호출
//        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
//        //// 광고가 표시될 때 호출(기기 화면을 덮음)
//        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
//        //// 광고 표시가 실패했을 때 호출
//        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
//        //// 광고를 시청한 후 보상을 받아야할 때 호출
//        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
//        //// 닫기 버튼을 누르거나 뒤로가기 버튼을 눌러 동영상 광고를 닫을 때 호출
//        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

//        // Create an empty ad request.
//        //AdRequest request = new AdRequest.Builder().
//        //    AddTestDevice("bc3ba8a89ed4bbc7ce8d0e007625783c").Build();

//        AdRequest request = new AdRequest.Builder().Build();
        
//        if (request == null) Debug.Log("요청이 널값입니다.");
//        // Load the rewarded ad with the request.
//        this.rewardedAd.LoadAd(request);

//        Debug.Log("this.rewardedAd.LoadAd(request);");


//        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        //// 광고 로드가 완료되면 호출
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        //// 광고 로드가 실패했을 때 호출
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        //// 광고가 표시될 때 호출(기기 화면을 덮음)
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        //// 광고 표시가 실패했을 때 호출
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        //// 광고를 시청한 후 보상을 받아야할 때 호출
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        //// 닫기 버튼을 누르거나 뒤로가기 버튼을 눌러 동영상 광고를 닫을 때 호출
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //MonoBehaviour.print(
        //    "HandleRewardedAdFailedToLoad event received with message: "
        //                     + args.Message);
        Debug.Log("실패");
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        Time.timeScale = 0;
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        if (uiManager == null)
        {
            uiManager = GameObject.FindObjectOfType<UIManager>();
        }
        uiManager.Resurrection();
    }

    public void ShowAds()
    {

        Debug.Log($"현재 광고 이름 : {rewardedAd}");
        Debug.Log($"현재 기기 이름 : {SystemInfo.deviceUniqueIdentifier}");
        Debug.Log($"로드 요청 : {this.rewardedAd.IsLoaded()}");
        if (rewardedAd == null)
            Debug.Log("광고가 없음");
        if (this.rewardedAd.IsLoaded())
        {
            Debug.Log("광고 시작");
            this.rewardedAd.Show();
        }
    }
}
