using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleSite : MonoBehaviour
{
    public List<ItemType> requires = new List<ItemType>();
    public string id;

    private int completetionLevel;

    public UnityEvent onCompleted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.gameObject.GetComponent<Item>();
        if (requires.Contains(item.ItemType)){ 
            completetionLevel += 1;
            item.gameObject.SetActive(false);
            if(completetionLevel == requires.Count){
                onCompleted.Invoke();
            }
        }
    }
}

