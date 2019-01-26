using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSite : MonoBehaviour
{
    public List<ItemType> requires = new List<ItemType>();
    private int completetion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.gameObject.GetComponent<Item>();
        if (requires.Contains(item.ItemType)){ 
            completetion += 1;
            item.gameObject.SetActive(false);
            if(completetion == requires.Count){
                Debug.Log("PUZZLE COMPLETE");
            }
        }
    }
}

