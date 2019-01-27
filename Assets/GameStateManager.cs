using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

    private float _effectT = -1f;
    private float _effectDur;
    private bool _flashing = false;
    private bool _startFading = false;
    private bool _gameOverFading = false;

    public float FadeDuration = 5f;
    public float FlashDuration = 0.25f;
    public Image FadeImage;
    public Image GameOverFlashImage;

    private void Update() {
        // If the effect is over, start the next one, or load the next Scene
        if (_effectT >= _effectDur) {
            if (_startFading)
                play();
            else if (_gameOverFading)
                gameOver();
            else if (_flashing) {
                _flashing = false;
                _gameOverFading = true;
                _effectT = 0f;
                _effectDur = FadeDuration;
                GameOverFlashImage.gameObject.SetActive(false);
            }
        }

        // Otherwise, continue the effect
        if (_effectT >= 0f) {
            if (!_flashing) {
                Color color = FadeImage.color;
                float startAlpha = _gameOverFading ? 0.25f : 0f;
                FadeImage.color = new Color(color.r, color.g, color.b, Mathf.Lerp(startAlpha, 1f, _effectT / _effectDur));
            }
            _effectT += Time.deltaTime;
        }
    }

    public void Play(bool immediately) {
        if (!immediately && FadeImage != null) {
            _effectT = 0f;
            _startFading = true;
            _effectDur = FadeDuration;
        }
        else
            play();
    }
    public void GameOver(bool immediately) {
        if (!immediately && FadeImage != null) {
            _effectT = 0f;
            _flashing = true;
            GameOverFlashImage.color = new Color(GameOverFlashImage.color.r, GameOverFlashImage.color.g, GameOverFlashImage.color.b, 1f);
            _effectDur = FlashDuration;
        }
        else
            gameOver();
    }
    public void Quit() => Application.Quit(0);

    private void play() => SceneManager.LoadScene("Main", LoadSceneMode.Single);
    private void gameOver() => SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

}
