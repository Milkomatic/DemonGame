using UnityEngine;

public class Player : MonoBehaviour {

    private Vector3 _startingScale;
    private Rigidbody2D _rb;
    private bool _flipped = false;

    public float Speed;
    public float PerspectiveScale;
    public Inventory Inventory;
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
        handleMove();
        handleInventory();
        handleScale();
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
        float scaleDelta = this.transform.position.y * -PerspectiveScale + .5f;
        if (IsUpstairs)
            scaleDelta += 0.5f;
        Vector3 newScale = _startingScale + scaleDelta * Vector3.one;
        if (_flipped)
            newScale.x *= -1f;
        ScalingRoot.localScale = newScale;
    }
    private void handleInventory() {
        // Pickup nearest item
        if (Input.GetButtonDown("Pickup"))
            Inventory.TryPickupItem();

        // Use or drop items
        if (Input.GetButtonDown("UseItem0"))
            Inventory.UseOrDropItem(0, _feet.transform.position);
        if (Input.GetButtonDown("UseItem1"))
            Inventory.UseOrDropItem(1, _feet.transform.position);
        if (Input.GetButtonDown("UseItem2"))
            Inventory.UseOrDropItem(2, _feet.transform.position);
    }

}
