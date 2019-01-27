using UnityEngine;

public class StairTrigger : MonoBehaviour {
    public bool IsUpstairs;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            IsUpstairs = !IsUpstairs;
            Player player = other.gameObject.GetComponent<Player>();
            player.IsUpstairs = IsUpstairs;
        }
    }
}
