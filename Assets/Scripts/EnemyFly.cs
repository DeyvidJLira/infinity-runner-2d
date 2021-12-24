using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 22/12/2021
 * @last_update 22/12/2021
 * @description classe responsável por controlar o inimigo do tipo Fly
 * 
 */

public class EnemyFly : EnemyBase {

    public override void Movement() {
        _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
    }

}
