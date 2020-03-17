using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class lvlunlocker : MonoBehaviour
{

    // Use this for initialization
    sceneLoader s;
    public Button[] btnsOfLvl;

  public  static  int  levelreached;
    public static int levelreachedCOunt;

    void Start()
    {
        s = GetComponent<sceneLoader>();
         levelreached = PlayerPrefs.GetInt("levelreached", 1);
        levelreachedCOunt = PlayerPrefs.GetInt("LRC", 1);  //to keep track of prev inttreactble bttns


        for (int i = 0; i < btnsOfLvl.Length; i++)

        {
             if (i + 1 > levelreached )
              {


                  btnsOfLvl[i].interactable = false; //setting all other btns deactive


              }

         
        }

        /*
         * // to aceess multiple btn feild fr cheking intercatblity
        foreach (Button ButtonTag1 in btnsOfLvl )
        {
           if( ButtonTag1.GetComponent<Button>().interactable )
            {
            
            }
        }



        //-------------------------------updating btns active
          if (TotalHealthRemaining <= 0)
        {
            // when sub total health of enemies is zero, all enemy dead animation play.. and detroy them all;
            Debug.Log("now heslth zero");


            PlayerPrefs.SetInt("LRC", lvlunlocker.levelreached);
            if(sceneLoader.currentLevel>=lvlunlocker.levelreachedCOunt)
            {
                PlayerPrefs.SetInt("levelreached", sceneLoader.currentLevel + 1); //unlocklevel  
            }
       
        }
        */
    }


    //*bjust to open level number n on clicking button n



    public static  int currentBtnLevelClicked;

    
    public void lvlOnclicked(int a)
    {

        currentBtnLevelClicked = a;

        SceneManager.LoadScene("basic");
        //instead  of loadscene(a); as our game has one scene only..


        
    }

  


}


