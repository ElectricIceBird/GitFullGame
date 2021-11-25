using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class admanager : MonoBehaviour
{
    private BannerView ad;
    // Start is called before the first frame update
    void Start()
    {
     MobileAds.Initialize(InitializationStatus => { });
        this.requestAd();
    }
    private void requestAd()
    {
        string adUnitId = "	ca-app-pub-3940256099942544/6300978111";
        this.ad = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest re = new AdRequest.Builder().Build();
        this.ad.LoadAd(re);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
