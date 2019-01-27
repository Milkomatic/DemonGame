using UnityEngine;

public class Player : MonoBehaviour {

    private Vector3 _startingScale;
    private Rigidbody2D _rb;
    private bool _flipped = false;
    private bool _hasBook = false;
    private bool _bookOpen = false;

    public float Speed;
    public float PerspectiveScale;
    public Inventory Inventory;
    public BookHolder BookHolder;
    public Transform ScalingRoot;
    public Animator Animator;
    public Transform SpriteTransform;
    public bool IsUpstairs;
    private GameObject _feet;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _startingScale = transform.localScale;
        _feet = this.transform.Find("perspective-scale-root").gameObject.transform.Find("collider").gameObject;
    }
    private void Update() {
        if (!_bookOpen) {
            handleMove();
            handleScale();
            handleInventory();
        }
        if (_hasBook)
            handleBook();
    }

    private void handleMove() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector2(moveHorizontal, moveVertical);
        _rb.position += (movement * Speed);

        //transform.Translate(movement * Time.deltaTime);
        //_rb.AddForce (movement * Speed);

        // Adjust animation parameters
        Animator.SetBool("moving", moveHorizontal != 0f || moveVertical != 0f);

        // Flip the Player when walking to the left
        _flipped = moveHorizontal < 0f;
    }
    private void handleScale() {
        float scaleDelta = this.transform.position.y * -PerspectiveScale;
        if (IsUpstairs)
            scaleDelta += 0.5f;
        Vector3 newScale = _startingScale + scaleDelta * Vector3.one;
        if (_flipped)
            newScale.x *= -1f;
        ScalingRoot.localScale = newScale;
    }
    private void handleInventory() {
        // Pickup nearest item
        if (Input.GetButtonDown("Pickup")) {
            Inventory.TryPickupItem();
            if (Inventory.LastPickedUpItem != null) {
                if (Inventory.LastPickedUpItem.ItemType == ItemType.Book)
                    _hasBook = true;
            }
        }

        // Use or drop items
        if (Input.GetButtonDown("UseItem0"))
            useOrDrop(0);
        if (Input.GetButtonDown("UseItem1"))
            useOrDrop(1);
        if (Input.GetButtonDown("UseItem2"))
            useOrDrop(2);

        void useOrDrop(int index){
            Item item = Inventory.Items[index];
            if (item != null) {
                if (item.ItemType == ItemType.Book)
                    _hasBook = false;
                Inventory.UseOrDropItem(index, _feet.transform.position);
            }
        }
    }
    private void handleBook() {
        // Open or close the book, if toggled
        if (Input.GetButtonDown("ToggleBook")) {
            if (_bookOpen)
                BookHolder.CloseBook();
            else
                BookHolder.OpenBook();
            _bookOpen = !_bookOpen;
        }

        // Close the book if its open and the user pressed cancel
        if (_bookOpen && Input.GetButtonDown("Cancel")) {
            BookHolder.CloseBook();
            _bookOpen = false;
        }

        // If the book is still open, turn pages
        if (_bookOpen) {
            if (Input.GetButtonDown("NextPage"))
                BookHolder.TryNextPage();
            if (Input.GetButtonDown("PreviousPage"))
                BookHolder.TryPreviousPage();
        }
    }

}
