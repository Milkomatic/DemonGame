using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

    private float _tElapsed = 0f;
    private bool _triggered = false;

    [Tooltip("In seconds...")]
    public float Duration;
    public UnityEvent TimeElapsed = new UnityEvent();

    private void Update() {
        if (_tElapsed >= Duration && !_triggered) {
            TimeElapsed.Invoke();
            _triggered = true;
        }

        _tElapsed += Time.deltaTime;
    }

}
