using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 22/12/2021
 * @last_update 27/12/2021
 * @description classe responsável por controlar o inimigo do tipo Fly
 * 
 */

public class EnemyFly : EnemyBase {
    public override void Movement() {
        
    }

    public override void MovementPhysics() {
        _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
    }

    protected override void Attack() {
        
    }

    protected override void Die() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            collision.GetComponent<Player>().OnHit(999);
        }
    }
}
