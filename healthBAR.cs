using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBAR : MonoBehaviour {



    //MOST EASY  WAY FOR HEALTH BAR



    // Use this for initialization
    Image healthbar;




	void Start () {
        healthbar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        healthbar.fillAmount =   health.healthLeft/50f;
		
	}
}
