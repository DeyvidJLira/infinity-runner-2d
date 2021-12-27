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
 * @description classe responsável por controlar a UI do Menu
 * 
 */

public class MenuUI : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

}
