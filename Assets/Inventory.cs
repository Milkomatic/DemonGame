using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private IList<Item> _nearbyItems = new List<Item>();
    private IList<Item> _items = new List<Item>();

    public Image[] ItemUISlots;
    public UnityEvent PickedUp = new UnityEvent();

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
        if (_nearbyItems.Count == 0)
            return;

        // Place item in the first available slot
        // If no slots are available then just return
        Item item = _nearbyItems[_nearbyItems.Count - 1];
        int index = -1;
        bool pickedUp = false;
        for (index = 0; index < _items.Count; ++index) {
            if (_items[index] == null) {
                _items[index] = item;
                pickedUp = true;
                break;
            }
        }
        if (!pickedUp)
            return;

        // Do pickup actions
        _nearbyItems.RemoveAt(_nearbyItems.Count - 1);  // Faster than removing the zero index

        Image img = ItemUISlots[index];
        img.sprite = item.InventorySprite;
        img.enabled = true;

        item.PickupRoot.gameObject.SetActive(false);
        item.DropRoot?.gameObject.SetActive(false);
    }
    public void UseOrDropItem(int index, Vector3 position) {
        if (index < 0 || _items.Count <= index)
            throw new ArgumentOutOfRangeException(nameof(index));

        // If there is no Item at this index then just return
        Item item = _items[index];
        if (item == null)
            return;

        _items[index] = null;

        Image img = ItemUISlots[index];
        img.sprite = null;
        img.enabled = false;

        Transform dropRoot = item.DropRoot ?? item.PickupRoot;
        dropRoot.position = position;
        dropRoot.gameObject.SetActive(true);
    }

}
