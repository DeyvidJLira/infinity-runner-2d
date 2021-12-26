using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Deyvid Jaguaribe
 * @website https://deyvidjlira.com/
 * 
 * @created_at 26/12/2021
 * @last_update 26/12/2021
 * @description classe responsável por controlar o tiro do jogador
 * 
 */

public class Missile : MonoBehaviour {

    private Rigidbody2D _rigidbody;

    [SerializeField]
    private GameObject _collisionEffect;

    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _speedX;

    // Start is called before the first frame update
    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _rigidbody.velocity = Vector2.right * _speedX;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag != "Player") {
            var objectDamageable = collision.GetComponent<IDamageable>();
            if (objectDamageable != null) {
                objectDamageable.OnDamage(_damage);
            }
            Instantiate(_collisionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

}