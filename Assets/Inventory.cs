using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private IList<Item> _nearbyItems = new List<Item>();
    private IList<Item> _items = new List<Item>();

    public Image[] ItemUISlots;

    private void Awake() {
        for (int i = 0; i < ItemUISlots.Length; ++i)
            _items.Add(null);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Item item = other.GetComponent<Item>();
        if (item == null)
            return;

        // Keep the nearby items sorted by distance (closest one last)
        bool added = false;
        float newItemSqrDist = (item.transform.position - transform.position).sqrMagnitude;
        for (int i = _nearbyItems.Count - 1; i >= 0; --i) {
            float itemSqrDist = (_nearbyItems[i].transform.position - transform.position).sqrMagnitude;
            if (newItemSqrDist < itemSqrDist) {
                _nearbyItems.Insert(i + 1, item);
                added = true;
                return;
            }
        }
        if (!added)
            _nearbyItems.Add(item);
    }
    private void OnTriggerExit2D(Collider2D other) {
        Item item = other.GetComponent<Item>();
        _nearbyItems.Remove(item);
    }


    public void TryPickupItem() {
        int index = _items.Count;
        Item item = _nearbyItems[0];
        _items.Add(item);
        _nearbyItems.RemoveAt(_nearbyItems.Count - 1);  // Faster than removing the zero index

        ItemUISlots[index].sprite = item.InventorySprite;

        item.gameObject.SetActive(false);
    }
    public void UseOrDropItem(int index, Vector3 position) {
        if (index < 0 || _items.Count <= index)
            throw new ArgumentOutOfRangeException(nameof(index));

        // If there is no Item at this index then just return
        Item item = _items[index];
        if (item == null)
            return;

        _items.RemoveAt(index);

        Image img = ItemUISlots[index];
        img.sprite = null;
        img.enabled = false;

        item.transform.position = position;
        item.gameObject.SetActive(true);
    }

}
