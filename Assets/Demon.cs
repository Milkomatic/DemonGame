using UnityEngine;
using UnityEngine.SceneManagement;

public class Demon : MonoBehaviour {

    public float TimeLeft;      // Seconds
    public bool IsBanished;

    private void Update() {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0 && !IsBanished)
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void Banish() {
        this.gameObject.SetActive(false);
        IsBanished = true;
    }

}
