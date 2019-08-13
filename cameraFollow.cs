using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{


    // A MUCH SIMPLER WAY OF DOING IS THIS IS MAKING THE CAMERA CHILD OF PLAYER

     Transform target;
  [SerializeField]  private Vector3 offset;



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

  
       void LateUpdate()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        transform.position = target.TransformPoint(offset);
        transform.rotation = target.rotation;//so that camera also rotate with gameobject
    }
}
