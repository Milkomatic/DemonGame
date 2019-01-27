using UnityEngine;

public enum ItemType {
    Candles,
    Book,
    Chalk,
    Salt,
    Key,
    Dagger,
    Sage,
    Matchbook,
    Crystal
}

public class Item : MonoBehaviour {

    public ItemType ItemType;
    public Sprite InventorySprite;
    public Transform PickupRoot;
    public Transform DropRoot;

}
