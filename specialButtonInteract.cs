using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specialButtonInteract : MonoBehaviour
{



    public static Button b1, b2, b3;
    public static Button b4;



    //----------------------button delayeerrrrrrrrrrr system..............................

    void Start()
    {
        //set lion btn interactble after 16f of game start

        b4= GameObject.Find("ButtonLion").GetComponent<Button>(); //to find a btn using its name

        Invoke("activeAgain4", 16f);
    }

    public void buttonFunction1( Button b) //assign parameter in btn onclick listener inspector....
    {
      
        b.interactable = false;//once clicked,becomes inactive
        Invoke("activeAgain1", 6f);//becomes active again after 6sec
        b1 = b;
    }

    public void buttonFunction2(Button b)
    {

        b.interactable = false;
        Invoke("activeAgain2", 6f);
        b2 = b;
    }
    public void buttonFunction3(Button b)
    {

        b.interactable = false;
        Invoke("activeAgain3", 6f);
        b3 = b;
    }
 



    void activeAgain1()
    {

        b1.interactable = true;
    }
    void activeAgain2()
    {

        b2.interactable = true;
    }
    void activeAgain3()
    {

        b3.interactable = true;
    }
    void activeAgain4()
    {
        //lion
        b4.interactable = true;
    }


}
