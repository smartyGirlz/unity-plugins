using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControl : MonoBehaviour


    //press ctrl+shift+f for camera adjustment same in both scene and game view
 
{
    public animPlayer ap;

    public CharacterController cctrl;
    public float movmentSpeed=12f;

    void Start()
    {
        cctrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        rotate();
        walkAnimate();
    }

 
    public void move()



    {
        // if(Input.GetAxis("vertical")>0)//means up arrow key pressed or w key


        if (Input.GetAxis(Tags.Axis.VERTICAL_AXIS) > 0)

        {
            Vector3 moveDirection = transform.forward;

            moveDirection.y -= 9.8f * Time.deltaTime;
            cctrl.Move(moveDirection * movmentSpeed * Time.deltaTime);

         

        }

        else if(Input.GetAxis(Tags.Axis.VERTICAL_AXIS) < 0)
            {

            Vector3 moveDirection = -transform.forward;

            moveDirection.y -= 9.8f * Time.deltaTime;
            cctrl.Move(moveDirection * movmentSpeed * Time.deltaTime);
        }

    }

    float rotateDegreesPerSecond = 180f;
    //ROTATE
    public void rotate()
    {
        Vector3 rotationDirection = Vector3.zero;

        if (Input.GetAxis("Horizontal") < 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.left);
        }

        if (Input.GetAxis("Horizontal") >0)
        {
            rotationDirection = transform.TransformDirection(Vector3.right);
        }

        if(rotationDirection!=Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotationDirection), rotateDegreesPerSecond * Time.deltaTime);
        }
    }


    public void walkAnimate()
    {
        if(cctrl.velocity.sqrMagnitude!=0f)
        {
            ap.walk(true);
            
            
        }
        else 
        {
           ap.walk(false);
        }
    }

}














