using UnityEngine;

public class Player : MonoBehaviour {

    private Vector3 _startingScale;
    private Rigidbody2D _rb;

    public float Speed;
    public float PerspectiveScale;
    public Inventory Inventory;
    public Transform ScalingRoot;
    public Animator Animator;
    public bool IsUpstairs;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _startingScale = transform.localScale;
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
        Animator.SetInteger("horizontal", (int)Mathf.Sign(moveHorizontal));
        Animator.SetInteger("vertical", (int)Mathf.Sign(moveVertical));
        //transform.Translate(movement * Time.deltaTime);
        //_rb.AddForce (movement * Speed);
    }
    private void handleScale(){
        if(!IsUpstairs){
            float perspectiveTransform = this.transform.position.y * -PerspectiveScale;
            ScalingRoot.localScale = _startingScale + new Vector3(perspectiveTransform,perspectiveTransform,perspectiveTransform);
        }else{
            float perspectiveTransform = this.transform.position.y * -PerspectiveScale + .5f;
            ScalingRoot.localScale = _startingScale + new Vector3(perspectiveTransform,perspectiveTransform,perspectiveTransform);
        }
    }
    private void handleInventory() {
        // Pickup nearest item
        if (Input.GetButtonDown("Pickup"))
            Inventory.TryPickupItem();

        // Use or drop items
        if (Input.GetButtonDown("UseItem0"))
            Inventory.UseOrDropItem(0, transform.position);
        if (Input.GetButtonDown("UseItem1"))
            Inventory.UseOrDropItem(1, transform.position);
        if (Input.GetButtonDown("UseItem2"))
            Inventory.UseOrDropItem(2, transform.position);
    }

}
