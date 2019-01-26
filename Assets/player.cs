using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
    public Inventory Inventory;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        handleMove();
        handleInventory();

    }
    private void handleMove() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector2(moveHorizontal, moveVertical);
        rb.position += (movement * Speed);
        //transform.Translate(movement * Time.deltaTime);
        //rb.AddForce (movement * Speed);
    }
    private void handleInventory() {
        if (Input.GetButtonDown("ToggleItem")) {

        }
        if (Input.GetButtonDown("UseItem1")) {

        }
        if (Input.GetButtonDown("UseItem2")) {

        }
        if (Input.GetButtonDown("UseItem3")) {

        }
    }
}
