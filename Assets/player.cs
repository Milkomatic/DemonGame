using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
    public float PerspectiveScale;
    public Inventory Inventory;
    public Transform ScalingRoot;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        handleMove();
        handleInventory();
    }
    private void handleMove() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float perspectiveTransform = moveVertical * -PerspectiveScale;
        var movement = new Vector2(moveHorizontal, moveVertical);
        _rb.position += (movement * Speed);
        ScalingRoot.localScale += perspectiveTransform * Vector3.one;
        //transform.Translate(movement * Time.deltaTime);
        //_rb.AddForce (movement * Speed);
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
