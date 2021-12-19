using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 15/12/2021
 * @last_update 15/12/2021
 * @description classe responsável por controlar o player
 * 
 */

public class Player : MonoBehaviour {

    [Header("Components")]
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Transform _groundDetector;
    [SerializeField]
    private LayerMask _groundMask;

    [Header("Attributes")]
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private float _jumpForce = 10f;
    private bool _onGround = false;

    private void OnEnable() {
        _playerInput.Enable();
    }

    private void OnDisable() {
        _playerInput.Disable();   
    }

    private void Awake() {
        _playerInput = new PlayerInput();
        _playerInput.Gameplay.Jump.performed += ctx => Jump();
    }

    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        OnGround();
        UpdateAnimations();
    }

    private void FixedUpdate() {
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }

    private void UpdateAnimations() {
        _animator.SetBool("onGround", _onGround);
    }

    private void Jump() {
        if(_onGround) {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnGround() {
        _onGround = Physics2D.Linecast(transform.position, _groundDetector.position, _groundMask);
    }
}
