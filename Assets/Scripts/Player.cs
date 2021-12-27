using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 15/12/2021
 * @last_update 27/12/2021
 * @description classe responsável por controlar o player
 * 
 */

public class Player : MonoBehaviour {

    [Header("Components")]
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
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

    private Color _normalColor = new Color(1, 1, 1, 1);
    private Color _hitColor = new Color(1, 1, 1, .2f);

    private bool _isInvencible = false;

    [Header("Attributes")]
    [SerializeField]
    private int _life = 3;
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

    public void OnHit(int damage) {
        if (_isInvencible) return;
        _life -= damage;
        if(_life <= 0) {
            GameManager.Instance.GameOver();
        } else {
            _isInvencible = true;
            StartCoroutine("Blink");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 9) {
            GameManager.Instance.GameOver();
        }
    }

    IEnumerator Blink() {
        for(int i = 0; i < 3; i++) {
            _spriteRenderer.color = _hitColor;
            yield return new WaitForSeconds(.3f);
            _spriteRenderer.color = _normalColor;
            yield return new WaitForSeconds(.3f);
        }
        _isInvencible = false;
    }
}
