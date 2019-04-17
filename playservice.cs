using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class playservice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        signIn();

    }

   // public Text status;

    public void signIn()
    {


        if(Social.localUser.authenticated)
        {
            return;
        }
        //authenticate user
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure

            /*   if(success==true)
               {
                   status.text = "sucees";        //its authenticatied in phone
               }
               else
               {
                   status.text = "failed";
               }*/
        });
    }



    public void showLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }


    int newscore = scores.score; 
    public string leaderBoardId;



    public void reportScore()
    {
        
        Social.ReportScore(newscore, GPGSIds.leaderboard_highest_scores_leaderboard, success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });

    }
}
