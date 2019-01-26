using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    public object inv;

    //private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
         //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
        HandleInv();
        
    }
    void HandleMove()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
        transform.Translate(movement * Time.deltaTime);
    }
    HandleInvc()
    {
        if(Input.GetKeyDown("E"))
        {
            
        }
        if(Input.GetKeyDown("1"))
        {
            
        }
        if(Input.GetKeyDown("2"))
        {
            
        }
        if(Input.GetKeyDown("2"))
        {
            
        }
    }
}
