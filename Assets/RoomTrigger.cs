using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private Vector3 _position;
    public float _transitionSpeed;

    void Start()
    {
        _position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _position, _transitionSpeed);;
        }
    }
}
