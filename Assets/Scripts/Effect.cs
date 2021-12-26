using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 26/12/2021
 * @last_update 26/12/2021
 * @description classe responsável gerenciar os efeitos
 * 
 */

public class Effect : MonoBehaviour {

    protected void OnAnimationFinished() {
        Destroy(gameObject);
    }

}
