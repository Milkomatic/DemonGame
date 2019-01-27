using UnityEngine;

public enum ItemType {
    Candles,
    Book,
    Chalk,
    Salt,
    Dagger,
    Sage,
    Matchbook,
    Crystal
}

public class Item : MonoBehaviour {

    public ItemType ItemType;
    public Sprite InventorySprite;

}
