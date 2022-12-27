using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour
{
    BannerView bannerView;
    string bannerID = "ca-app-pub-3940256099942544/6300978111";
    InterstitialAd interstitialAd;
    string interstitialID = "ca-app-pub-3940256099942544/1033173712"; 
    RewardedAd rewardedAd;
    string rewardedAdID = "ca-app-pub-3940256099942544/5224354917";

    void Start()
    {
        RequestBanner();
        RequestInterstitial();
        RequestRewardedAd();
    }

    void RequestBanner()
    {
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    void RequestInterstitial()
    {
        interstitialAd = new InterstitialAd(interstitialID);
        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        interstitialAd.Show();
        RequestInterstitial();
    }

    void RequestRewardedAd()
    {
        rewardedAd = new RewardedAd(rewardedAdID);
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        print("Reward given to the player");
        bannerView.Destroy();
    }

    public void ShowRewardedAd()
    {
        rewardedAd.Show();
        RequestRewardedAd();
    }
}
