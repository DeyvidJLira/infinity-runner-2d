using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 26/12/2021
 * @last_update 26/12/2021
 * @description interface para objetos que podem sofrer dano
 * 
 */

public interface IDamageable {

    void OnDamage(int damage);

}
