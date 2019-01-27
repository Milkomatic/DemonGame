using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnItemAccepted : UnityEvent<ItemType>
{
}

public class PuzzleSite : MonoBehaviour
{
    public List<ItemType> requires = new List<ItemType>();

    private int completetionLevel;
    public bool active;

    public UnityEvent onCompleted;
    public OnItemAccepted onItemAccepted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(active){
            var item = other.gameObject.GetComponent<Item>();
            if (requires.Contains(item.ItemType)){ 
                completetionLevel += 1;
                item.gameObject.SetActive(false);
                onItemAccepted.Invoke(item.ItemType);
                if(completetionLevel == requires.Count){
                    onCompleted.Invoke();
                    Deactivate();
                }
            }
        }
    }

    public void Activate(){
        active = true;
    }

    public void Deactivate(){
        active = false;
    }

    public void test(ItemType item){
        Debug.Log(item);
    }
}

