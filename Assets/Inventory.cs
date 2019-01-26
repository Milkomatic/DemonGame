using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private IList<Item> _items = new List<Item>();

    public Image[] ItemUISlots;

    private void Awake() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        int index = _items.Count;
        Item item = other.GetComponent<Item>();
        _items.Add(item);

        ItemUISlots[index].sprite = item.InventorySprite;

        item.gameObject.SetActive(false);
    }

    public void UseItem(int index, Vector3 position) {
        if (index < 0 || _items.Count <= index)
            throw new ArgumentOutOfRangeException(nameof(index));

        Item item = _items[index];
        _items.RemoveAt(index);

        ItemUISlots[index].sprite = null;

        item.transform.position = position;
        item.gameObject.SetActive(true);
    }

}
