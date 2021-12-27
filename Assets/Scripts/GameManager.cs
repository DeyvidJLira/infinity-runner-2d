using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 27/12/2021
 * @last_update 27/12/2021
 * @description classe responsável gerenciar operações que podem ser utilizadas em diferentes momentos por diferentes objetos
 * 
 */

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