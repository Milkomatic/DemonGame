using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

    private float _fadeT = -1f;

    public float FadeTime = 5f;
    public Image FadeImage;

    private void Update() {
        Color color = FadeImage.color;
        if (_fadeT >= FadeTime) {
            _fadeT = -1f;
            play();
        }
        if (_fadeT >= 0f) {
            FadeImage.color = new Color(color.r, color.g, color.b, Mathf.Lerp(0f, 1f, _fadeT / FadeTime));
            _fadeT += Time.deltaTime;
        }
    }

    public void Play(bool immediately) {
        if (!immediately && FadeImage != null)
            _fadeT = 0f;
        else
            play();
    }
    public void Quit() => Application.Quit(0);

    private void play() => SceneManager.LoadScene("Main", LoadSceneMode.Single);

}
