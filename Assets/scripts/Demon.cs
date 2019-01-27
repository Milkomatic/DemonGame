using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Demon : MonoBehaviour {

    public float TimeLeft;      // Seconds
    public bool IsBanished;

    public UnityEvent Timeout = new UnityEvent();

    private void Update() {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0 && !IsBanished) {
            enabled = false;
            Timeout.Invoke();
        }
    }

    public void Banish() => IsBanished = true;

}
