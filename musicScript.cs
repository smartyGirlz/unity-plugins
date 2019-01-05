using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour {

    // Use this for initialization

    static Object instance = null;
    void Start () {
        //to continually play music in bg 
        GameObject.DontDestroyOnLoad(gameObject);
	}




    

   

    void Awake()//no repeation of music k lie itta kuch
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    
    }

