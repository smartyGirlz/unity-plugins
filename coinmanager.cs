using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinmanager : MonoBehaviour
{


    private static string _coinKey = "Coin";
    public static coinmanager instance;


    void Start()
    {
       /* if (instance != null)
        {
            Destroy(this.gameObject);//if instance already exists,then we shud get rid of this gameObj
            return;
        }
        instance = this;
        */
    }


  


    public static int LoadCoin()

    {

        return PlayerPrefs.GetInt(_coinKey, 0);
    }


    private static void SaveCoin(int coin)
    {

        PlayerPrefs.SetInt(_coinKey, coin);

    }

    public static void AddCoin(int coin)

    {

        int totalCoin = LoadCoin() + coin;

        SaveCoin(totalCoin);

    }
    public static void DeductCoin(int coin)

    {

        int totalCoin = LoadCoin() - coin;

        SaveCoin(totalCoin);

    }

}




