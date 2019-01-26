using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    
    public void Banish()
    {
        this.gameObject.SetActive(false);
    }
}
