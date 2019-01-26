using UnityEngine;

public class RoomTrigger : MonoBehaviour {

    private Vector3 _position;
    private Transform _cameraTrans;

    public float TransitionSpeed;

    private void Start() {
        Transform trans = gameObject.transform;
        _position = new Vector3(trans.position.x, trans.position.y, -1);

        _cameraTrans = Camera.main.transform;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            _cameraTrans.position = Vector3.Lerp(_cameraTrans.position, _position, TransitionSpeed);
        }
    }
}
