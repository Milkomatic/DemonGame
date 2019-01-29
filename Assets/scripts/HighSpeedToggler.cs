using UnityEngine;

public class HighSpeedToggler : MonoBehaviour {

    private bool _highSpeed;

    public float HighSpeedTimeScale = 3f;

    private void Update() {
        if (Input.GetButtonDown("ToggleHighSpeed")) {
            _highSpeed = !_highSpeed;
            Time.timeScale = _highSpeed ? HighSpeedTimeScale : 1f;
        }
    }

}
