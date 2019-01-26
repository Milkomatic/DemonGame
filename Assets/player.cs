using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
    public float PerspectiveScale;
    public Inventory Inventory;
    public Transform ScalingRoot;
    private Vector3 startingScale;
    public bool isUpstairs;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        startingScale = transform.localScale;
    }

    // Update is called once per frame
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
    }

    private void handleScale(){
        if(!isUpstairs){
            float perspectiveTransform = this.transform.position.y * -PerspectiveScale;
            ScalingRoot.localScale = startingScale + new Vector3(perspectiveTransform,perspectiveTransform,perspectiveTransform);        
        }else{
            float perspectiveTransform = this.transform.position.y * -PerspectiveScale + .5f;
            ScalingRoot.localScale = startingScale + new Vector3(perspectiveTransform,perspectiveTransform,perspectiveTransform);        
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
