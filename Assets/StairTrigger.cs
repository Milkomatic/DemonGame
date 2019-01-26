using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTrigger : MonoBehaviour
{
    public bool isUpstairs;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player"){
            isUpstairs = !isUpstairs;
            var player = other.gameObject.GetComponent<Player>();
            player.IsUpstairs = isUpstairs;
        }
    }
}
