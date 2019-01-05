using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chechNetwork : MonoBehaviour {

 

    public GameObject NoInternet;
  

    void Start()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {

           NoInternet.gameObject.SetActive(true);
        }
    }
}

