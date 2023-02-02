﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;

public class WatchAdsForMoney : MonoBehaviour
{
    private RewardedAd rewardBasedVideo;

#if UNITY_IOS
    private string appId = "ca-app-pub-4962234576866611~7650244366";

    private string gameID = "4601830";
#else
    private string appId = "ca-app-pub-4962234576866611~9568876446";

    private string gameID = "4601831";
#endif


    public Text coins;

    void Start()
    {
        Advertisement.Initialize(gameID, false);
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        InitAdmobRewarded();
    }


    void InitAdmobRewarded()
    {
    #if UNITY_IOS
        this.rewardBasedVideo = new RewardedAd("ca-app-pub-4962234576866611/6120157389");
    #else
        this.rewardBasedVideo = new RewardedAd("ca-app-pub-4962234576866611/9859911671");
    #endif

        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideo.LoadAd(request);

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
        this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
        this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
        this.rewardBasedVideo.OnUserEarnedReward += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;

        request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideo.LoadAd(request);
    }

    public void Clickonrewardreqest()
    {
        InitAdmobRewarded();
    }
    public void Clickonrewardshow()
    {
        this.ShowRewardBasedVideo();
    }
    
    private bool ShowRewardBasedVideo()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();

            return true;
        }
        else
        {
            return false;
        }
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        InitAdmobRewarded();
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //reward
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 20);
        coins.text = PlayerPrefs.GetInt("coins").ToString();
    }
    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        //

        Debug.Log("The ad was skipped before reaching the end.");
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    void cleanHandles()
    {
        rewardBasedVideo.OnAdLoaded -= HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening -= HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnUserEarnedReward -= HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
    }


    public void showAdsForMoney()
    {
        if (!ShowRewardBasedVideo())
        {
            ShowOptions options = new ShowOptions();
            options.resultCallback = AdCallbackHandler;
            if (Advertisement.IsReady("Android_Rewarded"))
            {
                Advertisement.Show("Android_Rewarded", options);
            }
        }
    }

    void AdCallbackHandler(ShowResult res)
    {
        if (res == ShowResult.Finished)
        {
            //reward
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 20);
            coins.text = PlayerPrefs.GetInt("coins").ToString();

        }
        else if (res == ShowResult.Skipped)
        {
            Debug.Log("skipped");
        }
        else if (res == ShowResult.Skipped)
        {
            Debug.Log("error");
        }
    }
}
