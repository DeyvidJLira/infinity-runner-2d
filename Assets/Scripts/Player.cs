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

    [Header("Attributes")]
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private float _jumpForce = 10f;

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

    private void FixedUpdate() {
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }

    private void Jump() {
        _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
    }
}
