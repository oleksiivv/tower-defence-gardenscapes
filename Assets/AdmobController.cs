using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;

public class AdmobController : MonoBehaviour
{
    private InterstitialAd intersitional;
    private BannerView banner;

    private string appId="ca-app-pub-4962234576866611~9568876446";
    private string intersitionalId="ca-app-pub-4962234576866611/1695267611";
    private string bannerId="ca-app-pub-4962234576866611/1517311825";

    void Start(){
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        RequestConfigurationAd();

        //RequestBannerAd();
        Advertisement.Initialize("4601827", false);
    }

     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }


      void RequestConfigurationAd(){
          intersitional=new InterstitialAd(intersitionalId);
          AdRequest request=AdRequestBuild();
          intersitional.LoadAd(request);

          intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
          intersitional.OnAdOpening+=this.HandleOnAdOpening;
          intersitional.OnAdClosed+=this.HandleOnAdClosed;

      }


      public bool showIntersitionalAd(){
          if(intersitional.IsLoaded()){
              intersitional.Show();

              return true;
          }
          else{
            if(Advertisement.IsReady("Interstitial_Android") ){
                Advertisement.Show("Interstitial_Android");
            }
          }

          return false;
      }

      private void OnDestroy(){
          DestroyIntersitional();

          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

      }

      private void HandleOnAdClosed(object sender, EventArgs e)
      {
          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

            RequestConfigurationAd();

        
      }

      private void HandleOnAdOpening(object sender, EventArgs e)
    {
        
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        
    }

 

     public void DestroyIntersitional(){
         intersitional.Destroy();
     }




    //baner

    public void RequestBannerAd(){
        banner=new BannerView(bannerId,AdSize.Banner,AdPosition.Top);
        AdRequest request = AdRequestBannerBuild();
        banner.LoadAd(request);
    }

    public void DestroyBanner(){
        if(banner!=null){
            banner.Destroy();
        }
    }



    AdRequest AdRequestBannerBuild(){
        return new AdRequest.Builder().Build();
    }
}
