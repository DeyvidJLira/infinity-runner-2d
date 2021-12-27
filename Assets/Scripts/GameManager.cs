using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance {
        get {
            return _instance;
        }
        private set {
            _instance = value;
        }
    }

    private static GameManager _instance;

    private GameOverUI gameOverUI;

    private void Awake() {
        if(_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else if(_instance != this) {
            Destroy(gameObject);
        }
    }

    public void RegisterGameOverUI(GameOverUI value) {
        gameOverUI = value;
    }

    public void GameOver() {
        gameOverUI.ShowGameOver();
        Time.timeScale = 0;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}