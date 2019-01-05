using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraColor : MonoBehaviour {

    // Use this for initialization

    Camera cam;

    public float duration = 3.0F;

    public Color c1, c2;

    void Start()
    {
        cam = GetComponent<Camera>();

        cam.clearFlags = CameraClearFlags.SolidColor;

    }


        // Update is called once per frame
        void Update() {

        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(c1, c2, t);
      
   

    }
    } 
