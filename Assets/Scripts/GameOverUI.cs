using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 26/12/2021
 * @last_update 26/12/2021
 * @description classe responsável pelo gerenciamento da UI de GameOver
 * 
 */

public class GameOverUI : MonoBehaviour {

    [SerializeField]
    private GameObject _gameOverPanel;

    private void Start() {
        GameManager.Instance.RegisterGameOverUI(this);
    }

    public void ShowGameOver() {
        _gameOverPanel.SetActive(true);
    }

    public void ClickRestart() {
        GameManager.Instance.Restart();
    }
}
