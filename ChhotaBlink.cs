using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChhotaBlink : MonoBehaviour
{

    public float reparrate;

    // Use this for initialization
    void Start()
    {

        InvokeRepeating("Blink", 0, reparrate);
    }

    void Blink()
    {
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }

        else
        {
            this.gameObject.SetActive(true);
        }

    }
}
