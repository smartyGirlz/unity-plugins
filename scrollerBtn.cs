using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scrollerBtn : MonoBehaviour
{
    public void MoveContentPane(float value)  //attach method to scroll btn...>
    {
        var pos = transform.position;
        pos.x += value;
        transform.position = pos;
    }

    

    public void reloadscene()
    {
        SceneManager.LoadScene("selectLevel");
    }


    public void loadFirstScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
