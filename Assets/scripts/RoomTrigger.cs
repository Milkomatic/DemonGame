using UnityEngine;
using UnityEngine.Events;

public class RoomTrigger : MonoBehaviour {

    private Vector3 _position;
    private Transform _cameraTrans;

    public bool IgnoringReentries;
    public float TransitionSpeed;
    public uint TimesEnterred = 0;
    public int RaiseEventAfterReentries = 1;
    public UnityEvent ReEnterred = new UnityEvent();

    public void SetIgnoringReentries(bool ignoring) => IgnoringReentries = ignoring;

    private void Awake() {
        Transform trans = gameObject.transform;
        _position = new Vector3(trans.position.x, trans.position.y, -1);

        _cameraTrans = Camera.main.transform;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (!IgnoringReentries && other.gameObject.name == "Player") {
            ++TimesEnterred;
            if (TimesEnterred == RaiseEventAfterReentries)
                ReEnterred.Invoke();
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Player")
            _cameraTrans.position = Vector3.Lerp(_cameraTrans.position, _position, TransitionSpeed);
    }

}
