using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ItemEntry {
    public ItemType ItemType;
    public GameObject Sprite;
}

public class PuzzleSite : MonoBehaviour {
    private List<ItemType> _requiredItems = new List<ItemType>();
    private int _completetionLevel;

    public List<ItemEntry> ItemEntries = new List<ItemEntry>();
    public bool Active;
    public UnityEvent OnCompleted;

    private void Start() {
        for (int e = 0; e < ItemEntries.Count; ++e)
            _requiredItems.Add(ItemEntries[e].ItemType);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (!Active)
            return;

        Item item = other.gameObject.GetComponent<Item>();
        if (!_requiredItems.Contains(item.ItemType))
            return;

        _completetionLevel += 1;
        item.gameObject.SetActive(false);
        ItemPlaced(item.ItemType);
        if (_completetionLevel == _requiredItems.Count) {
            OnCompleted.Invoke();
            Deactivate();
        }
    }
    public void ItemPlaced(ItemType type) {
        for (int e = 0; e < ItemEntries.Count; ++e) {
            if (ItemEntries[e].ItemType == type)
                ItemEntries[e].Sprite.SetActive(true);
        }
    }
    public void Activate() => Active = true;
    public void Deactivate() => Active = false;
}

