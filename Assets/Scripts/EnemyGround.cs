using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 24/12/2021
 * @last_update 26/12/2021
 * @description classe responsável por controlar o inimigo do tipo Ground
 * 
 */

public class EnemyGround : EnemyBase {

    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private Transform _firePoint;

    private bool _isAttacking = false;
    private float _timeShootElapsed = 0f;
    [SerializeField]
    private float _timeShootDelay = 2f;

    public override void Movement() {
        _timeShootElapsed += Time.deltaTime;

        if(_timeShootElapsed >= _timeShootDelay && !_isAttacking) {
            _isAttacking = true;
            Attack();
        }
    }

    public override void MovementPhysics() {
        
    }

    protected override void Attack() {
        _animator.SetTrigger("attack");
        Instantiate(_projectile, _firePoint.position, Quaternion.identity);
    }

    protected override void Die() {
        _animator.SetTrigger("die");
    }

    protected void OnFinishedDieAnimation() {
        Destroy(gameObject);
    }

    protected void FinishedAttack() {
        _timeShootElapsed = 0f;
        _isAttacking = false;
    }
}