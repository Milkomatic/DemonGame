using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemEntry
{
    public ItemType type;
    public GameObject sprite;
}

public class PuzzleSite : MonoBehaviour
{
    private List<ItemType> requires = new List<ItemType>();
    public List<ItemEntry> itemEntry = new List<ItemEntry>();     

    private int completetionLevel;
    public bool active;

    public UnityEvent onCompleted;

    private void Start(){
         foreach (var item in itemEntry)
         {
          requires.Add(item.type);   
         }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(active){
            var item = other.gameObject.GetComponent<Item>();
            if (requires.Contains(item.ItemType)){ 
                completetionLevel += 1;
                item.gameObject.SetActive(false);
                ItemPlaced(item.ItemType);
                if(completetionLevel == requires.Count){
                    onCompleted.Invoke();
                    Deactivate();
                }
            }
        }
    }

    public void ItemPlaced(ItemType type){
        foreach(var entry in itemEntry){
            if(entry.type == type){
                entry.sprite.SetActive(true);
            }
        }
    }

    public void Activate(){
        active = true;
    }

    public void Deactivate(){
        active = false;
    }
}

