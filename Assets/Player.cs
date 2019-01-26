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

        //transform.Translate(movement * Time.deltaTime);
        //_rb.AddForce (movement * Speed);

        // Adjust animation parameters
        int horzParam = (moveHorizontal == 0f) ? 0 : (moveHorizontal > 0f) ? 1 : -1;
        int vertParam = (moveVertical == 0f) ? 0 : (moveVertical > 0f) ? 1 : -1;
        Animator.SetInteger("horizontal", horzParam);
        Animator.SetInteger("vertical", vertParam);
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
