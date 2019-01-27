using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private IList<Item> _nearbyItems = new List<Item>();
    private List<Item> _items = new List<Item>();

    public Image[] ItemUISlots;
    public Text PickupTxt;
    public Item LastPickedUpItem { get; private set; }
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


    public IReadOnlyList<Item> Items => _items;
    public void TryPickupItem() {
        if (_nearbyItems.Count == 0)
            return;

        // Get the closest, active/enabled Item
        // Sometimes recently dropped items get added to the list of nearby Items but are still inactived by Puzzle sites,
        // so this block ignores those Items
        Item item;
        do {
            item = _nearbyItems[_nearbyItems.Count - 1];
            if (item.isActiveAndEnabled)
                break;
            else {
                _nearbyItems.RemoveAt(_nearbyItems.Count - 1);
                item = null;
            }
        } while (_nearbyItems.Count > 0);
        if (item == null)
            return;


        // Place item in the first available slot
        // If no slots are available then just return
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

        LastPickedUpItem = item;
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
