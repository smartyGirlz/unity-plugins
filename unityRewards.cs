using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class unityRewards: MonoBehaviour, IUnityAdsListener
{

    public string gameId;
    string myPlacementId = "rewardedVideo";
    bool testMode = true;
   // public Button myButton;









    void Start()
    {
       


       Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);

    }


    // Implement a function for showing a rewarded video ad:
  public   void ShowRewardedVideo()
    {
        
        Advertisement.Show(myPlacementId);
     
    }




    // Implement IUnityAdsListener interface methods:





    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)


    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            Debug.Log("i give reward here");
            coinmanager.AddCoin(5);
            Advertisement.RemoveListener(this); //its very imp in scene change..else the fuck exponential reward will be given
       
        }






        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
           //Advertisement.Show(myPlacementId); //agar ready he to show ni karna h, jab btn click kare tab shw karna h
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }



    public void addingscoeresCheck()
    {
        coinmanager.AddCoin(5);
    }



}

    

    