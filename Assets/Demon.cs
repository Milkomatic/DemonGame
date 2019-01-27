using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Demon : MonoBehaviour
{

    public float timeLeft;
    public bool isBanished;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if ( timeLeft < 0 && !isBanished )
        {
                 SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    public void Banish()
    { 
        this.gameObject.SetActive(false);
        isBanished = true;
    }
}
