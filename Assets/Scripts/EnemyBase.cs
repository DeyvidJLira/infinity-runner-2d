using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 22/12/2021
 * @last_update 22/12/2021
 * @description classe responsável por definir a básico para o inimigo
 * 
 */

abstract public class EnemyBase : MonoBehaviour {

    protected Rigidbody2D _rigidbody;
    
    [Header("Attributes")]
    [SerializeField]
    protected int _life = 3;
    [SerializeField]
    protected float _speed = 2f;

    private bool _isActive = false;

    // Start is called before the first frame update
    protected void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate() {
        if (!_isActive) return;
        Movement();
    }
    protected void OnBecameVisible() {
        _isActive = true;
    }

    protected void OnBecameInvisible() {
        if (_isActive) Destroy(gameObject);
    }

    abstract public void Movement();

}