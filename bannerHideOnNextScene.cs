/*The most straightforward approach is to link the lifecycle of ads to that of the scenes they’re displayed in. When transitioning from one scene to another, existing ads are destroyed before leaving the first scene.New ads can then be created and displayed in the next scene.

The downside of this approach is that every scene transition would result in a new banner request.This may not be desirable if scene transitions are frequent and occur quickly.

An alternative is to use a GameObject as a wrapper for banners or interstitials.By default, each GameObject in a scene will be destroyed once the new scene is loaded(unless you use additive scene loading). However, you can make a GameObject survive across scenes by marking it with DontDestroyOnLoad.You can then use the GameObject.Find method to obtain references to the wrapper GameObject from scripts in other scenes. 


Here is an example of how to use a GameObject to wrap banner ads:

// FirstSceneScript.cs

void Start() {

    // Create a wrapper GameObject to hold the banner. Mark the GameObject not to be destroyed when     new scenes load.

    GameObject myGameObject = new GameObject("myBannerAdObject");

    myGameObject.AddComponent<BannerWrapper>();

    DontDestroyOnLoad(myGameObject);

}


The BannerWrapper GameObject is a wrapper for a BannerView.

// BannerWrapper.cs


using System;


using UnityEngine;

using GoogleMobileAds;

using GoogleMobileAds.Api;


public class BannerWrapper : MonoBehaviour
{



    public BannerView bannerView;



    void Start()

    {

        bannerView = new BannerView("your_ad_unit_id", AdSize.SmartBanner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);



        bannerView.Show();

    }

}


In SecondSceneScript.cs, which is attached to the second scene, you can find a GameObject by name, get the BannerWrapper component, and access the BannerView:

// SecondSceneScript.cs


void Start () {

    GameObject myGameObject = GameObject.Find("myBannerAdObject");

    BannerWrapper bannerWrapper = myGameObject.GetComponent<BannerWrapper>();

    bannerWrapper.bannerView.Hide();

}



Whether your ad request script will create a new banner every time the scene is loaded would
depend on the logic of your ad request script.Also, our interstitial ads are displayed in their
own activities/ view controllers.You would not need to create a new scene for them to be displayed within.
*/