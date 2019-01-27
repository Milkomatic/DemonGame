using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public void Play() => SceneManager.LoadScene("Main", LoadSceneMode.Single);
    public void Quit() => Application.Quit(0);

}
