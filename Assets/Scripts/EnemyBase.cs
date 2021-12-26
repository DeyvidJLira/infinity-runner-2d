using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 22/12/2021
 * @last_update 26/12/2021
 * @description classe responsável por definir a básico para o inimigo
 * 
 */

abstract public class EnemyBase : MonoBehaviour, IDamageable {

    protected Animator _animator;
    protected Rigidbody2D _rigidbody;
    protected Collider2D _collider;

    [Header("Attributes")]
    [SerializeField]
    protected EnemyType _enemyType;
    [SerializeField]
    protected int _life = 3;
    [SerializeField]
    protected float _speed = 2f;

    private bool _isActive = false;

    // Start is called before the first frame update
    protected void Start() {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    protected void Update() {
        if (!_isActive) return;
        Movement();
    }

    protected void FixedUpdate() {
        if (!_isActive) return;
        MovementPhysics();
    }
    protected void OnBecameVisible() {
        _isActive = true;
    }

    protected void OnBecameInvisible() {
        if (_isActive) Destroy(gameObject);
    }

    abstract public void Movement();

    abstract public void MovementPhysics();

    abstract protected void Attack();

    abstract protected void Die();

    public void OnDamage(int damage) {
        _life -= damage;
        if(_life <= 0) {
            _collider.enabled = false;
            _isActive = false;
            Die();
        }
    }
}

public enum EnemyType { FLY, GROUND }