using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 15/12/2021
 * @last_update 26/12/2021
 * @description classe responsável por controlar o player
 * 
 */

public class Player : MonoBehaviour {

    [Header("Components")]
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private Animator _animator;

    [Header("Ground Collision")]
    [SerializeField]
    private Transform _groundDetector;
    [SerializeField]
    private LayerMask _groundMask;

    [Header("Shoot")]
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private GameObject _shootPrefab;
    [SerializeField]
    private float _shootIntervalTime;
    private float _shootElapsedTime = 0f;

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
        _playerInput.Gameplay.Shoot.performed += ctx => Shoot();
    }

    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        OnGround();
        UpdateAnimations();

        _shootElapsedTime += Time.deltaTime;
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

    private void Shoot() {
        if(_shootElapsedTime >= _shootIntervalTime) {
            Instantiate(_shootPrefab, _firePoint.position, transform.rotation);
            _shootElapsedTime = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 9) {
            GameManager.Instance.GameOver();
        }
    }
}
