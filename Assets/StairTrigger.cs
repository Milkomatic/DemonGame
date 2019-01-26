using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTrigger : MonoBehaviour
{
    public bool isUpstairs;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yee");
        if(!isUpstairs){
            var player = other.gameObject.GetComponent<Player>();
            player.ScalingRoot.localScale = Vector3.one;
        }
        if(isUpstairs){
            var player = other.gameObject.GetComponent<Player>();
            player.ScalingRoot.localScale = Vector3.one; //change for correct perspective
        }
        isUpstairs = !isUpstairs;
    }
}
