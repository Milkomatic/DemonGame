using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
    public Inventory Inventory;

    //private Rigidbody rb;
    // Start is called before the first frame update
    private void Start() {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() {
        handleMove();
        handleInventory();

    }
    private void handleMove() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.Translate(movement * Time.deltaTime);
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
