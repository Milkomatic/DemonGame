using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{

    public float timeLeft;

    void Update()
    {
         timeLeft -= Time.deltaTime;
        if ( timeLeft < 0 )
        {
            //GameOver();
        }
    }

    public void Banish()
    {
        this.gameObject.SetActive(false);
    }
}
