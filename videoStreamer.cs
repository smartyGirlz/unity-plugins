
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;



// This script won't work without a VideoPlayer present,
// so let's ask Unity to enforce that relationship for us.
[RequireComponent(typeof(VideoPlayer))]
public class videoStreamer : MonoBehaviour
{

    

    // Don't create/size the Array in Start() - that makes an empty
    // array, discarding the clips you assigned in the Inspector.
    public VideoClip[] vids = new VideoClip[26];

    private VideoPlayer vp;

    AudioSource ac;

  



    void Start()
    {
        vp = gameObject.GetComponent<VideoPlayer>();
       FindObjectOfType<soundManager>().GetComponent<AudioSource>().Pause();  //to pause cinematic track while playing video


        if (lvlunlocker.currentBtnLevelClicked%3==0|| lvlunlocker.currentBtnLevelClicked == 1)
        {
            Debug.Log("current level value in videostreamer is " + lvlunlocker.currentBtnLevelClicked);
            Time.timeScale = 0; //to pause bgm
            PlayVideo(lvlunlocker.currentBtnLevelClicked);   //    //  PlayVideo(1); 

            vp.loopPointReached += setDeactivevideo;
        }

        else
        {
            gameObject.SetActive(false);
        }
    

        //    vp.loopPointReached += LoadScene;   //where loadscene is a method
    }

    // Call this method when it's time to play a particular video.
    // Pass a number from 0 to 25 inclusive to choose which video.




    public void  PlayVideo(int id)
    {
        // To be safe, let's bounds-check the ID 
        // and throw a descriptive error to catch bugs.
        if (id < 0 || id >= vids.Length)
        {
            Debug.LogErrorFormat(
               "Cannot play video #{0}. The array contains {1} video(s)",
                                   id, vids.Length);
            return;
        }




        // If we get here, we know the ID is safe.
        // So we assign the (id+1)th entry of the vids array as our clip.
        vp.clip = vids[id];

        vp.Play();

   
    }




    public void setDeactivevideo(VideoPlayer vp) ///it works like that for video endpoint recahed
    {
        this.gameObject.SetActive(false);
        FindObjectOfType<soundManager>().GetComponent<AudioSource>().Play();  //to PLAY  cinematic track while playing video

        Time.timeScale = 1;
    }






}


    
